using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destructible : MonoBehaviour
{
    public GameObject[]itemDrops;
    public int Health = 100;

    public GameObject EnemyParticle;

    public void TakeDamage(int Damage)
    {
        Health -= Damage;
        if (Health < 0)
        {
            Instantiate(EnemyParticle, transform.position, Quaternion.identity);
            Destroy(gameObject);
            ItemDrop();
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void ItemDrop()
    {
        for (int i = 0; i < itemDrops.Length; i++)
        {
            Instantiate(itemDrops[i], transform.position, Quaternion.identity);
        }
    }
}
