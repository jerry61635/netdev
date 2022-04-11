using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float health;

    private void Start()
    {
        HealthBar.Instance.maxHealth = 100f;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            HealthBar.Instance.TakeDamage(20);
        }

        if(HealthBar.Instance.getHealth() == 0)
        {
            Destroy(gameObject);
        }
    }
}
