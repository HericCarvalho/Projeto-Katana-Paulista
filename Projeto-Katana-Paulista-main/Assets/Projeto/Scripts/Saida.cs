using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using Unity.VisualScripting.FullSerializer;

public class Saida : MonoBehaviour
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
        SceneManager.LoadScene("2°Fase - Cidade -");
    }
}
