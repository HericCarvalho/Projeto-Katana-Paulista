using UnityEngine;

public class Anarquista : MonoBehaviour
{
    [SerializeField] private float Vel;

    [SerializeField] private Rigidbody2D rig;
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private Animator animator;

    private void FixedUpdate()
    {
        Movimento();
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
    }
}
