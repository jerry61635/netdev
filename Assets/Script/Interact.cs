using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interact : MonoBehaviour
{
    public float radious = 3f;

    [SerializeField] private Animator anim;
    private bool doorState = false;

    public static Interact instance;
    #region Singleton
        /// <summary>
        /// Awake is called when the script instance is being loaded.
        /// </summary>
        void Awake()
        {
            if(instance == null) instance = this;
        }
    #endregion
    /// <summary>
    /// Callback to draw gizmos that are pickable and always drawn.
    /// </summary>

    public virtual void Interaction(){
        Debug.Log("Interacting");
    }

    /// <summary>
    /// Update is called every frame, if the MonoBehaviour is enabled.
    /// </summary>
    void Update()
    {
        GameObject Player = GameObject.FindGameObjectWithTag("Player");
    }

    /// <summary>
    /// OnTriggerStay is called once per frame for every Collider other
    /// that is touching the trigger.
    /// </summary>
    /// <param name="other">The other Collider involved in this collision.</param>
    void OnTriggerStay(Collider other)
    {
        if(other.tag == "Player"){
            if(Sight.instance.object_found){
                if(Player_Movement.instance.interact){
                    if(!doorState){
                        Debug.Log("test");
                        anim.Play("DoorOpen",0,0f);
                        doorState = !doorState;
                    }
                    else{
                        anim.Play("DoorClose",0,0f);
                        doorState = !doorState;
                    }
                }
            }
        }
    }

    void GetPlayer(){
    }
}
