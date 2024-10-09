using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class Anarquista : MonoBehaviour
{
    [SerializeField] private float Vel;
    private float jumpTimeCounter;
    [SerializeField] private float jumpTime;
    [SerializeField] private float jumpForce;

    private bool isJumping;

    [SerializeField] private Rigidbody2D rig;
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private Animator animator;
    [SerializeField]private BoxCollider2D hitbox;

    private string estado;
    private string AR = "ar";
    private string CHAO = "chao";


    private void FixedUpdate()
    {
        Movimento();
    }
    private void Update()
    {
        Jump();
        animação();
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
            Vel = 300;
        }
        else
        {
            this.animator.SetBool("Correndo", false);
            Vel = 100;
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
    private void Ataque ()
    {
        if (Input.GetButtonDown("FIRE1")) // Attack on Space key press.
        {
            animator.SetTrigger("MeleeAttack");
            Invoke("ActivateHitbox", 0.2f); // Activate hitbox after 0.2 seconds.
            Invoke("DeactivateHitbox", 0.4f); // Deactivate hitbox after 0.4 seconds.
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
        hitbox.gameObject.SetActive(true);
    }

    void DeactivateHitbox()
    {
        hitbox.gameObject.SetActive(false);
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
}
