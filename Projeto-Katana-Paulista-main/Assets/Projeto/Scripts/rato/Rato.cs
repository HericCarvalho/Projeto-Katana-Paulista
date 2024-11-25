using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using Vector2 = UnityEngine.Vector2;
using Vector3 = UnityEngine.Vector3;

public class Rato : MonoBehaviour
{
    public float Velocidade;
    public GameObject pontoA;
    public GameObject pontoB;
    private Rigidbody2D rb;
    private Transform currentPoint;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        currentPoint = pontoB.transform;
    }

    void Update()
    {
        Vector2 ponto = currentPoint.position - transform.position;
        if (currentPoint == pontoB.transform)
        {
            rb.velocity = new Vector2(Velocidade, 0);
        }
        else
        {
            rb.velocity = new Vector2(-Velocidade, 0);
        }

        if (Vector2.Distance(transform.position, currentPoint.position) < 0.5f && currentPoint == pontoB.transform)
        {
            Flip();
            currentPoint = pontoA.transform;
        }
        if (Vector2.Distance(transform.position, currentPoint.position) < 0.5f && currentPoint == pontoA.transform)
        {
            Flip();
            currentPoint = pontoB.transform;
        }
    }

    private void Flip()
    {
        Vector3 localScale =transform.localScale;
        localScale.x *= -1;
        transform.localScale = localScale;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.SendMessage("Damage", 1);
        }
    }
    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(pontoB.transform.position, 0.5f);
        Gizmos.DrawWireSphere(pontoA.transform.position, 0.5f);
    }
}
