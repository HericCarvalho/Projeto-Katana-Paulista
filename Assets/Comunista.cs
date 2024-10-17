using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;

public class Comunista : MonoBehaviour
{
    #region Variaveis
    public enemy_state CurrentState;
    public Patrulha_state patrolstate;
    public PlayerD_state playerDstate;
    public Charge_state chargeState;
    public Rigidbody2D rb;
    public Transform ledgeDetector;
    //private Animator anim;
    public LayerMask groundlayer, obstacleLayer, playerLayer;
    public float raycastDistance, obstacleDistance, playerDistance;
    public float speed;
    public int  facingDirection = 1;
    private bool playerDetected;
    public float DetectionPause;
    public float stateTime; 
    public float playerDWaitTime = 1;
    public float chargeTime;
    public float chargeSpeed;

    #endregion
    #region Unity callbacks
    private void Awake()
    {
        patrolstate = new Patrulha_state(this, "patrol");
        playerDstate = new PlayerD_state(this, "player detected");
        chargeState = new Charge_state(this, "charge");
        
        CurrentState = patrolstate;
        CurrentState.Enter();
    }
    private void Update()
    {
        CurrentState .LogicUpdate();
      
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        CurrentState.PhysicsUpdate();
       
    }

    public bool CheckForObstacles ()
    {
        RaycastHit2D hit = Physics2D.Raycast(ledgeDetector.position, Vector2.down, raycastDistance, groundlayer);
        RaycastHit2D hitObstacle = Physics2D.Raycast(ledgeDetector.position, Vector2.down, obstacleDistance, obstacleLayer);

        if (hit.collider == null || hitObstacle.collider == true)
        {
            Debug.Log("cade o ch�o");
            return true;
        }
        else
        {
            return false;
        }
    }
   public bool CheckForPlayer()
    {
        RaycastHit2D hitplayer = Physics2D.Raycast(ledgeDetector.position, facingDirection ==1 ? Vector2.right : Vector2.left, playerDistance, playerLayer);

        if (hitplayer.collider == true)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    #endregion  

    #region Outras fun��es
    private void OnDrawGizmos()
    {
       Gizmos.DrawRay(ledgeDetector.position, (facingDirection ==1 ? Vector2.right : Vector2.left) * playerDistance);
    }
    
    public void SwitchState(enemy_state newState)
    {
        CurrentState.Exit();
        CurrentState = newState;
        CurrentState.Enter();
        stateTime = Time.time;
    }
    #endregion
}
