using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Barra_Overdose : MonoBehaviour

{
    public Slider barra;

    public void SetMaxOverdose(int Drug)
    {
        barra.maxValue = Drug;
        barra.value = Drug;
    }
    public void SetOverdose(int Drug)
    {
        barra.value = Drug;
    }
}
