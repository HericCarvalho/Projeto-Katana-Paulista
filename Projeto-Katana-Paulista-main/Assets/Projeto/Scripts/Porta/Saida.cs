using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Saida : MonoBehaviour
{
    [SerializeField] private string proximafase;
    [SerializeField] private BoxCollider2D BoxCollider2D;

    private void FixedUpdate()
    {
        Carregarproximafase();
    }
    private void Carregarproximafase()
    {
        SceneManager.LoadScene(proximafase);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (collision.gameObject.tag == "Player")
            {
                Carregarproximafase();
            }
        }
    }
}
