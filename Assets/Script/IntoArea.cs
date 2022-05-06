using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntoArea : MonoBehaviour
{
    bool spawn_enemy = false;

    [SerializeField]
    private Transform[] SpawnArea;

    [SerializeField]
    private GameObject[] Enemies;

    public float SpawnRate;
    private float Current_Spawn_time = 0;

    List<GameObject> enemies = new List<GameObject>();

    Collider WallCollider;

    void Start()
    {
        WallCollider = GetComponentInChildren<Collider>();
    }


    void Update()
    {
        if (spawn_enemy)
        {
            Current_Spawn_time += Time.deltaTime;
            if (Current_Spawn_time >= SpawnRate) 
            {
                int enemy_ID = Random.Range(0, Enemies.Length);
                int spawn_position = Random.Range(0, SpawnArea.Length);
                enemies.Add(Instantiate(Enemies[enemy_ID], SpawnArea[spawn_position].transform.position, SpawnArea[spawn_position].transform.rotation));

                Current_Spawn_time = 0;
                Debug.Log("Enemy Spawn! Spawn ID: " + enemy_ID);
                
            }
        }
    }

    void LateUpdate()
    {
        spawn_enemy = false;
    }
    
    void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (spawn_enemy)
            {
                spawn_enemy = false;
                foreach (GameObject i in enemies){
                    Destroy(i);
                }
                enemies.Clear();
            }
            else
                spawn_enemy = true;
        }
    }

}
