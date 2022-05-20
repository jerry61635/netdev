using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoulBoss : MonoBehaviour
{
    enum EnemyState {IDLE , Chase , Attack}
    EnemyState enemyState;

    [SerializeField]
    GameObject[] players;

    void State_Switch(){
        switch(enemyState){
            case EnemyState.IDLE:
                //Idle Animation
                break;
            case EnemyState.Chase:
                
                break;
            case EnemyState.Attack:
                //Attack player , attack decide , attack animation
                break;  
        }
    }
    /// <summary>
    /// Update is called every frame, if the MonoBehaviour is enabled.
    /// </summary>
    void Update()
    {
        players = GameObject.FindGameObjectsWithTag("Player");
    }
}
