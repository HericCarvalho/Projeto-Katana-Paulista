using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Remedio : MonoBehaviour
{
    private Anarquista player;
    private void Awake()
    {
        player = FindObjectOfType<Anarquista>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.SendMessage("Drug", -1);
        }

        Destroy(gameObject);
    }
}
