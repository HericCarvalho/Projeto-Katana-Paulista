using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class TiroEnenmy : MonoBehaviour
{
    private GameObject player;
    private Rigidbody2D rb;
    public float Force;
    private float timer;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player");

        Vector2 direction = player.transform.position - transform.position;
        rb.velocity = new Vector2(direction.x, direction.y).normalized * Force;

        float rot = Mathf.Atan2(-direction.y, -direction.x) *Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0,0,rot + 90);
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer > 2)
        {
            Destroy(gameObject);
        }
    }

   void OnTriggerEnter2D(Collider2D other)
    {
       if (other.gameObject.CompareTag("Player"))
        {
            other.gameObject.SendMessage("Damage", 3);
            Destroy(gameObject);    
        }
    }
}
