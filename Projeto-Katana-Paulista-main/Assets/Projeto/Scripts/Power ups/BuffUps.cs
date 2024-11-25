using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuffUps : MonoBehaviour
{
    public Barra_VIda Barra_VIda;

    public enum Powerup{Health, Speed}
    public Powerup powerups;

    public int AmountToGive;
    private Anarquista player;

    private void Awake()
    {
        player = FindObjectOfType<Anarquista>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            switch (powerups) 
            {
                case Powerup.Health:
                    player.health += AmountToGive;
                    Barra_VIda.SetHealth(player.health);

                    Debug.Log("cade a cura>");
                    break;
                case Powerup.Speed:
                    player.Vel += AmountToGive;
                    Debug.Log("cade a vel");
                    break;
                default:
                    break;
            }

            Destroy(gameObject);
        }
    }
}
