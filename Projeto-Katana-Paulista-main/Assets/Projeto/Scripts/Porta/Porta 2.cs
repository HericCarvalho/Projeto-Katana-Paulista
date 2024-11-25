using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Porta2 : MonoBehaviour
{
    [SerializeField] private Transform target; //Outra porta
    private Transform player; //Jogador
    [SerializeField] private KeyCode key; //Tecla que aperta para teleportar
    [SerializeField] private float currentDistance; //Distancia entre a porta e o jogador
    [SerializeField] private float maxDistance; //Distancia maxima para teleportar
    [SerializeField] private Animator animator;


    void Start()
    {
        player = GameObject.FindWithTag("Player").transform; //Pega o jogador e seta automaticamente na variavel player
    }


    void Update()
    {
        if (target != null)
        { //Verifica se a outra porta esta linkado
            currentDistance = Vector2.Distance(transform.position, player.position); //Pega a distância entre a porta e o jogador
            if (currentDistance <= maxDistance)
            { //Verifica se a distância é menor ou igual a distância maxima.
                if (Input.GetKeyDown(key))
                { //Verifica se o jogador apertou a tecla de teleport
                    player.position = target.position; //Jogador é teleportado para a outra porta.
                }
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        this.animator.SetBool("Fechado?", false);
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        this.animator.SetBool("Fechado?", true);
    }
}