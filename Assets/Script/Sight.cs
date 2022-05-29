using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sight : MonoBehaviour
{
    #region Singleton
        public static Sight instance;
        /// <summary>
        /// Awake is called when the script instance is being loaded.
        /// </summary>
        void Awake()
        {
            if(instance == null) instance = this;
        }
    #endregion

    float hitDistance = 20f;
    int layerMask;
    RaycastHit hit;

    public bool object_found = false;

    // Start is called before the first frame update
    void Start()
    {
        layerMask = 1 << 7;
        //print(layerMask);
    }

    // Update is called once per frame
    void Update()
    {
        if(Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, hitDistance, layerMask)){
            Vector3 forward = transform.TransformDirection(Vector3.forward) * hitDistance;
            Debug.DrawRay(transform.position, forward, Color.green);
            if(hit.transform.tag == "Interactable")
                object_found = true;
        }
        else object_found = false;
    }
}
