using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static BuffUps;

public class Coca : MonoBehaviour
{
    public float SpeedUp = 2.5f;
    public float SpeedUpDur = 5f;
    public int AmountToGive;
    private Barra_Overdose overdose;

    private Anarquista player;
    private void Awake()
    {
        player = FindObjectOfType<Anarquista>();
    }

    void Update()
    {
        Time.timeScale += (1f / SpeedUpDur) * Time.unscaledDeltaTime;
        Time.timeScale = Mathf.Clamp(Time.timeScale, 0f, 1f);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.SendMessage("Droga", 1);
            collision.gameObject.SendMessage("SetTimeScaleItem", new float[] { SpeedUp, SpeedUpDur });



        }

        Destroy(gameObject);
    }


}
