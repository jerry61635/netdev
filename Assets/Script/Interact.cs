using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interact : MonoBehaviour
{
    public float radious = 3f;
    public GUIStyle LabelStyle;
    public Color LabelColor = Color.black;
    public int textWidth = 120;
    public int textHeight = 50;

    [SerializeField] private Animator anim;
    private bool doorState = false;

    public static Interact instance;
    #region Singleton
        void Awake()
        {
            if(instance == null) instance = this;
        }
    #endregion
    
    
    void Start()
    {
        LabelStyle.normal.textColor = LabelColor;
    }

    void Update()
    {
        GameObject Player = GameObject.FindGameObjectWithTag("Player");
        if(Sight.instance.object_found){
            if(Player_Movement.instance.interact){
                if(!doorState)
                    anim.Play("DoorOpen",0,0f);
                else
                    anim.Play("DoorClose",0,0f);
                doorState = !doorState;
            }
        }
    }

    void OnGUI()
    {
        if(Sight.instance.object_found) {
            DrawGUI();
        }
    }

    void DrawGUI(){
        GUILayout.BeginArea(new Rect((Screen.width - textWidth) / 2,(Screen.height - textHeight) / 2, textWidth, textHeight));
        if(!doorState) GUILayout.Label("Press E Open Door", LabelStyle);
        else GUILayout.Label("Press E Close Door", LabelStyle);
        GUILayout.EndArea();
    }

}
