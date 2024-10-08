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

    [SerializeField] private string estado;
    private string AR = "ar";
    [SerializeField] private string CHAO = "chao";

    enum Estado
    {
        Ar,
        Chao
    }

    private void FixedUpdate()
    {
        Movimento();
    }
    private void Update()
    {
        Jump();
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
            print("pulo");
        }


        if (Input.GetKey(KeyCode.Space))
        {
            if (jumpTimeCounter > 0)
            {
                rig.velocity = Vector2.up * jumpForce;
                jumpTimeCounter -= Time.deltaTime;
            }
            else { isJumping = false; }
        }

        if (Input.GetKeyUp(KeyCode.Space))
        {
            isJumping = false;
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
}
