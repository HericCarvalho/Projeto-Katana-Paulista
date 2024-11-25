using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class saida2 : MonoBehaviour
{
    [SerializeField] BoxCollider2D boxCollider;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Invoke("proximaFase", 1f);
        }
    }
    void proximaFase()
    {
        SceneManager.LoadScene("3°Fase Final");
    }
}
