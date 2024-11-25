using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NovoTeleporte : MonoBehaviour
{
    [SerializeField] private Transform destination;

    [SerializeField] private bool Aberto;
    [SerializeField] private Animator animator;
    [SerializeField] private BoxCollider2D BoxCollider2D;

     public Transform GetDestination()
    {
        return destination;
    }
   
    void FixedUpdate()
    {
        Abrir();
    }
    void Abrir()
    {
        if (Aberto == true)
        {
            this.animator.SetBool("Fechado?", false);
        }
        else if (Aberto == false)
        {
            this.animator.SetBool("Fechado?", true);
        }
    }
    private void OnTriggerEnter2D()
    {
        Aberto = true;
    }
    private void OnTriggerExit2D()
    {
        Aberto = false;
    }
   
}
