using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    [SerializeField] private Transform alvo;

    [SerializeField] private float aceleraçãoCamera;
    
    private void Start()
    {

        
    }
    void Update()
    {
        Vector3 posiçãoFinal = this.alvo.position;
        posiçãoFinal.z = this.transform.position.z;
        posiçãoFinal.y = this.transform.position.y;
        
        posiçãoFinal = Vector3.Lerp(this.transform.position, posiçãoFinal, this.aceleraçãoCamera * Time.deltaTime);

        this.transform.position = posiçãoFinal;
    }
}
