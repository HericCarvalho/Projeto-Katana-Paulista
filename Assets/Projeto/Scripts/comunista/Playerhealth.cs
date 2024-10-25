  using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour, IDamageable
{
    public int health;
    public int maxHealth = 20;

        private void Start()
    {
        health = maxHealth;
    }
    public void Damage(float damageAmount)
    {
        Debug.Log("megadano");
        health -= (int)damageAmount;

    }

    private void Update()
    {
        if (health <= 0)
            Destroy(gameObject);
    }
}
