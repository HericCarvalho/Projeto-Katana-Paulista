using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Comunista : MonoBehaviour
{
    public GameObject pontoA;
    public GameObject pontoB;
    private Rigidbody2D rb;
    private Animator anim;
    private Transform currentPoint;
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        currentPoint = pontoB.transform;
        anim.SetBool("isRunning", true);
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 point = currentPoint.position - transform.position;
        if (currentPoint == pontoB.transform)
        {
            rb.velocity = new Vector2(speed, 0);
        }
        else
        {
            rb.velocity = new Vector2(-speed, 0);
        }
        if(Vector2.Distance(transform.position,currentPoint.position) < 0.5f && currentPoint == pontoB.transform)
        {
            Flip();
            currentPoint = pontoA.transform;
        }
        if(Vector2.Distance(transform.position, currentPoint.position) < 0.5f && currentPoint == pontoA.transform)
        {
            Flip();
            currentPoint = pontoB.transform;
        }
    }
    private void Flip()
    {
        Vector2 localScale = transform.localScale;
        if (currentPoint == pontoB.transform)
        {
            localScale.x = -1;
            transform.localScale = localScale;
        }
        else
        {
            localScale.x =1;
            transform.localScale = localScale;
        }
        
    }
}
