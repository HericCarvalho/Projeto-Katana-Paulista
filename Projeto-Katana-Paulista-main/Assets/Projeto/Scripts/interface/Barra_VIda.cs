using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Barra_VIda : MonoBehaviour
{

     public Slider barra;


    public void SetMaxHealth(int health)
    {
        barra.maxValue = health;
        barra.value = health;
    }

    public void SetHealth(int health)
    {
        barra.value = health;
    }

}
