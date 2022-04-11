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

    void Start()
    {
        
    }


    void Update()
    {
        if (spawn_enemy)
        {
            Debug.Log("Player inside");
            Current_Spawn_time += Time.deltaTime;
            if (Current_Spawn_time >= SpawnRate) 
            {
                int enemy_ID = Random.Range(0, Enemies.Length);
                int spawn_position = Random.Range(0, SpawnArea.Length);
                Instantiate(Enemies[enemy_ID], SpawnArea[spawn_position].transform.position, SpawnArea[spawn_position].transform.rotation);

                Current_Spawn_time = 0;
                Debug.Log("Enemy Spawn! Spawn ID: " + enemy_ID);
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player inside");
            spawn_enemy = !spawn_enemy;
        }
    }

}
