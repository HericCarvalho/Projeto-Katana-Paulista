using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tirov2 : MonoBehaviour
{
    GameObject target;
    public float speed;
    Rigidbody2D tiroRB;
    Transform player;
    private float timer;
    

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        tiroRB = GetComponent<Rigidbody2D>();
        target = GameObject.FindGameObjectWithTag("Player");
        Vector2 moveDir = (target.transform.position - transform.position).normalized*speed;
        tiroRB.velocity = new Vector2(moveDir.x, moveDir.y);
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
        timer += Time.deltaTime;
        if (timer > 2)
        {
            Destroy(gameObject);
        }

    }

    private void OnTriggerEnter2D(Collider2D other)
    {

        if (other.gameObject.CompareTag("Player"))
        {
            other.gameObject.SendMessage("Damage", 3);
            
        }
        Destroy(gameObject);
    }
}

