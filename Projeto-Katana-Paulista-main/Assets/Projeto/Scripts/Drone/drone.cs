using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class drone : MonoBehaviour,IDamageable
{
    public float speed;
    public bool chase = false;
    public Transform pontoinicio;
    private GameObject player;
    public float Vida;
    public float MAxVida=10;
    void Start()
    {
        Vida = MAxVida;
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (player == null)
        {
            return;
        }
        if (chase == true)
        {
            Chase();
        }
        else
        {
            ReturnStartingPoint();
        }
        Flip();
    }
    private void Chase()
    {
        transform.position = Vector2.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);
    }
    private void ReturnStartingPoint()
    {
        transform.position = Vector2.MoveTowards(transform.position, pontoinicio.position, speed * Time.deltaTime);
    }
    private void Flip()
    {
        if (transform.position.x > player.transform.position.x)
        {
            transform.rotation = Quaternion.Euler(0, 180, 0);
        }
        else
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.SendMessage("Damage", 10);

        }
        Destroy(gameObject);
    }

    public void Damage(float damageAmount)
    {
    }

    public void Damage(float damageAmount, float KBForce, Vector2 KBAngle)
    {
        Vida -= damageAmount;
    }
}
