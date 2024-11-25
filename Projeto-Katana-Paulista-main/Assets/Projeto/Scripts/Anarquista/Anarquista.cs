using System;
using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class Anarquista : MonoBehaviour, IDamageable
{
    public int health;
    public int maxHealth = 20;
    public Barra_VIda Barra_VIda;
    public Barra_Overdose Barra_Overdose;
    private BuffUps buff;
    public int Drug;
    public float damage;
    public float KBForce;
    public Vector2 KBAngle;


    [SerializeField] public float Vel;
    private float jumpTimeCounter;
    [SerializeField] private float jumpTime;
    [SerializeField] private float jumpForce;

    private bool isJumping;

    [SerializeField] private Rigidbody2D rig;
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private Animator animator;
    [SerializeField] private BoxCollider2D hitboxD;
    [SerializeField] private BoxCollider2D hitboxE;

    private string estado;
    private string AR = "ar";
    private string CHAO = "chao";

    void Start()
    {
        Drug = 0;
        Barra_Overdose.SetOverdose(Drug);
        health = maxHealth;
        Barra_VIda.SetMaxHealth(maxHealth);

    }

    public void Damage(float damageAmount)
    {
        health -= (int)damageAmount;
        Barra_VIda.SetHealth(health);
    }

    public void Damage(float damageAmount, float KBForce, Vector2 KBAngle)
    {
    }

    public void Droga(int drugAmount)
    {
        Drug += (int)drugAmount;
        Barra_Overdose.SetOverdose(Drug);
    }



    private void FixedUpdate()
    {
        Movimento();
    }
    private void Update()
    {
        Jump();
        animação();
        Ataque();
        if (health <= 0)
            Destroy(gameObject);
        if (Drug >= 5)
            Destroy(gameObject);


        //apaga
        if (Input.GetKeyDown(KeyCode.Q))
        {
            Time.timeScale = 1;
            Debug.Log("blab lablalsdf");
        }
    }

    private void Movimento()
    {
        float horizontal = Input.GetAxis("Horizontal");
        Vector2 velocidade = this.rig.velocity;
        velocidade.x = horizontal * this.Vel * Time.deltaTime;
        this.rig.velocity = velocidade;

        if (velocidade.x > 0)
        {
            this.spriteRenderer.flipX = false;

        }
        else if (velocidade.x < 0)
        {
            this.spriteRenderer.flipX = true;

        }
        if (velocidade.x > 0 || velocidade.x < 0)
        {
            float velocidadeX = Mathf.Abs(rig.velocity.x);

            this.animator.SetBool("Andando", true);
        }
        else
        {
            this.animator.SetBool("Andando", false);
        }

        if (Input.GetKey(KeyCode.LeftShift))
        {

            this.animator.SetBool("Correndo", true);
            Vel = 400;
        }
        else
        {
            this.animator.SetBool("Correndo", false);
            Vel = 200;
        }

    }



    private void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && estado == CHAO)
        {
            rig.velocity = Vector2.up * jumpForce;
            jumpTimeCounter = jumpTime;
        }


        if (Input.GetKey(KeyCode.Space))
        {
            if (jumpTimeCounter > 0)
            {

                rig.velocity = Vector2.up * jumpForce;
                jumpTimeCounter -= Time.deltaTime;
            }
            else
            {
                isJumping = false;
            }

        }

        if (Input.GetKeyUp(KeyCode.Space))
        {
            isJumping = false;
        }
    }
    private void Ataque()
    {
        if (Input.GetButtonDown("Fire1")) // Attack on Space key press.
        {
            this.animator.SetBool("Ataque", true);
            Invoke("ActivateHitbox", 0.2f); // Activate hitbox after 0.2 seconds.
            Invoke("DeactivateHitbox", 0.4f); // Deactivate hitbox after 0.4 seconds.
        }
        else
        {
            this.animator.SetBool("Ataque", false);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Chão")
        {
            estado = CHAO;
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (estado == CHAO)
        {
            if (collision.gameObject.tag == "Chão")
                estado = AR;
        }
    }
    void ActivateHitbox()
    {
        if (this.spriteRenderer.flipX == false)
        {
            hitboxD.gameObject.SetActive(true);
        }
        if (this.spriteRenderer.flipX == true)
        {
            hitboxE.gameObject.SetActive(true);
        }
    }

    void DeactivateHitbox()
    {
        hitboxD.gameObject.SetActive(false);
        hitboxE.gameObject.SetActive(false);
    }
    void animação()
    {
        float velocidadeY = rig.velocity.y;

        if (estado == AR)
        {
            if (velocidadeY > 0)
            {
                this.animator.SetBool("Pulando", true);
                this.animator.SetBool("Caindo", false);
            }
            else if (velocidadeY < 0)
            {
                this.animator.SetBool("Pulando", false);
                this.animator.SetBool("Caindo", true);
            }
        }
        else if (estado == CHAO)
        {
            this.animator.SetBool("Caindo", false);

        }
    }
    public void SetTimeScaleItem(float[] ble)
    {
        StartCoroutine(TempoTimeScale(ble[0], ble[1]));
    }
    IEnumerator TempoTimeScale(float timeScale, float tempo)
    {
        Debug.Log("TimeScale:" + timeScale + " tempo:" + tempo);
        Time.timeScale = timeScale;
        DateTime t = System.DateTime.Now;
        yield return new WaitForSeconds(tempo * timeScale);
        Debug.Log("Terminou" + (System.DateTime.Now - t));
        Time.timeScale = 1;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        IDamageable damageable = collision.GetComponent<IDamageable>();

        if (damageable != null)
        {
            ActivateHitbox();
            int FacingDirection = transform.position.x > collision.transform.position.x ? -1 : 1;
            damageable.Damage(damage, KBForce, new Vector2 (KBAngle.x * FacingDirection, KBAngle.y));
            Debug.Log("bateu");
        }

    }

}


