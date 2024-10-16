using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;

public class Comunista : MonoBehaviour
{
  
    public Rigidbody2D rb;
    public Transform ledgeDetector;
    //private Animator anim;
    public LayerMask groundlayer, obstacleLayer, playerLayer;
    public float raycastDistance, obstacleDistance, playerDistance;
    public float speed;
    private bool facingRight = true;
    private bool playerDetected;
    public float DetectionPause;
    // Start is called before the first frame update

    private void Update()
    {
        CheckForObstacles();
        CheckForPlayer();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (!playerDetected)
        {
            if (facingRight)
            {
                rb.velocity = new Vector2(speed, rb.velocity.y);
            }
            else
            {
                rb.velocity = new Vector2(-speed, rb.velocity.y);

            }
        }
    }

    void CheckForObstacles ()
    {
        RaycastHit2D hit = Physics2D.Raycast(ledgeDetector.position, Vector2.down, raycastDistance, groundlayer);
        RaycastHit2D hitObstacle = Physics2D.Raycast(ledgeDetector.position, Vector2.down, obstacleDistance, obstacleLayer);

        if (hit.collider == null || hitObstacle.collider == true)
        {
            Debug.Log("cade o chão");
            Flip();
        }
    }
    void CheckForPlayer()
    {
        RaycastHit2D hitplayer = Physics2D.Raycast(ledgeDetector.position, facingRight ? Vector2.right : Vector2.left, playerDistance, playerLayer);

        if (hitplayer.collider == true)
        {
            StartCoroutine(PLayerDetected());
        }
        else if (playerDetected)
        {
            StartCoroutine(PlayerNotDetected());
        }
    }

    IEnumerator PLayerDetected()
    {
        Debug.Log("player");
        playerDetected= true;
        rb.velocity = Vector2.zero; 
        yield return new WaitForSeconds(DetectionPause);
    }
    IEnumerator PlayerNotDetected()
    {
        yield return new WaitForSeconds(DetectionPause);
        playerDetected= false;
    }

    void Flip()
    {
        facingRight =!facingRight;
        transform.Rotate(0, 180, 0);
    }
    private void OnDrawGizmos()
    {
       Gizmos.DrawRay(ledgeDetector.position, (facingRight ? Vector2.right : Vector2.left) * playerDistance);
    }

}
