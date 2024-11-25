using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Relógio : MonoBehaviour
{
    public GameObject Display;

    public int minuto;
    public int segundos;
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {

        minuto = System.DateTime.Now.Minute;
        segundos = System.DateTime.Now.Second;
        Display.GetComponent<Text>().text = "" + minuto + ":" + segundos;
    }
}
