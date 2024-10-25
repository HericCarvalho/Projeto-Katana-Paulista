using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tiro : MonoBehaviour
{
    public GameObject tiro;
    public Transform tiroPos;

    private GameObject player;
    private float timer;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    #region distancia
    void Update()
    {
        float distance = Vector2.Distance(transform.position, player.transform.position);


        if (distance < 10)
        {
            timer += Time.deltaTime;

            if (timer > 2)
            {
                timer = 0;
                Shoot();
            }
        }
        
    }
    #endregion

    void Shoot()
    {
        Instantiate(tiro, tiroPos.position, Quaternion.identity);
    }
}
