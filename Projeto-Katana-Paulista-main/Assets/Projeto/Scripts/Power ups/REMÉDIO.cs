using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class REMÉDIO : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.SendMessage("Droga", -1);
        }
        Destroy(gameObject);
    }
}
