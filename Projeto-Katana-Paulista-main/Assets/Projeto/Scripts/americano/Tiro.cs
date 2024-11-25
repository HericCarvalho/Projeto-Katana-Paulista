using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tiro : MonoBehaviour, IDamageable
{
    public float turnDelay = .1f;
    public GameObject tiro;
    public Transform tiroPos;
    public Animator anim;
    public float Vida;
    public float MaxVida = 15;

    private GameObject player;
    private float timer;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>(); 
        Vida = MaxVida;
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
            this.anim.SetBool("atirando", true);


            if (timer > 1)
            {
                timer = 0;
          
                Shoot();
            }
           
            
        }
        else
        {
            this.anim.SetBool("atirando", false);
        }


    }
    #endregion

    void Shoot()
    {
        Instantiate(tiro, tiroPos.position, Quaternion.identity);
        
    }

    public void Damage(float damageAmount)
    {
    }

    public void Damage(float damageAmount, float KBForce, Vector2 KBAngle)
    {
        Vida -= damageAmount;


        if (Vida <= 0)
        {
            this.anim.SetBool("morre", true);
            Destroy(gameObject, 1f);


        }
        else
        {
            this.anim.SetBool("morre", false);
            this.anim.SetBool("dano", true);

        }
    }
}
