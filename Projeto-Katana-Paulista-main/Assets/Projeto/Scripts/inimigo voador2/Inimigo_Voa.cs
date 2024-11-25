using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inimigo_Voa : MonoBehaviour, IDamageable
{
    public float speed;
    private Transform player;
    public float lineOfSite;
    public float tiroRange;
    public GameObject tiro;
    public GameObject tiroPos;
    public float tiroRate = 1f;
    private float tiroSpeed;
    public float Vida;
    public float MaxVida = 10;

    void Start()
    {
        Vida = MaxVida;
        player=GameObject.FindGameObjectWithTag("Player").transform;

    }

    void Update()
    {
        float distanceFromPlayer = Vector2 .Distance(player.position, transform.position);
        if (distanceFromPlayer <lineOfSite && distanceFromPlayer>tiroRange) 
        {
            transform.position = Vector2.MoveTowards(this.transform.position, player.position, speed * Time.deltaTime);

        }
        else if (distanceFromPlayer <= tiroRange && tiroSpeed < Time.time)
        {
            Instantiate(tiro,tiroPos.transform.position,Quaternion.identity);
            tiroSpeed = Time.time + tiroRate;
        }
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, lineOfSite);
        Gizmos.DrawWireSphere(transform.position, tiroRange);

    }

    public void Damage(float damageAmount)
    {
     
    }

    public void Damage(float damageAmount, float KBForce, Vector2 KBAngle)
    {
        Vida -= damageAmount;
    }
}

