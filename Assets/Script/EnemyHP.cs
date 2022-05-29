using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHP : MonoBehaviour
{
    public float maxHP = 1000f;

    public float nowHP;

    public Image hpImage;

    public static EnemyHP Instance;

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
    }


    // Start is called before the first frame update
    void Start()
    {
        nowHP = maxHP;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TakeDamage(float damage)
    {
        

        if( nowHP <=0 )
        {
            return;
        }

        nowHP -= damage;

        if(nowHP <= 0)
        {
            nowHP = 0;
            Destroy(gameObject);

        }
        Debug.Log(hpImage);
        hpImage.fillAmount = nowHP / maxHP ;

    }

    

}
