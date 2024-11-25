using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inimigo_Voa : MonoBehaviour
{
    public float speed;
    private Transform player;
    public float lineOfSite;
    public float tiroRange;
    public GameObject tiro;
    public GameObject tiroPos;
    public float tiroRate = 1f;
    private float tiroSpeed;

    void Start()
    {
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
}

