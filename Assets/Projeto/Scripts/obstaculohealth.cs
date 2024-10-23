using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class obstaculohealth : MonoBehaviour, IDamageable
{
    public int health;

    public void Damage(float damageAmount)
    {
        Debug.Log("danozão");
        health -= (int)damageAmount;
    }

    private void Update()
    {
        if (health <= 0)
            Destroy(gameObject);
    }
}
