using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;

public class Comunista : MonoBehaviour, IDamageable
{
    #region Variaveis
    public enemy_state CurrentState;
    public Patrulha_state patrolstate;
    public PlayerD_state playerDstate;
    public Charge_state chargeState;
    public AtaqueMelee meleeAttackState;
    public DamagedState damagedState;
    public DeathState deathState;
    public Rigidbody2D rb;
    public Transform ledgeDetector;
    public Animator anim;
    public LayerMask groundlayer, obstacleLayer, playerLayer, damageableLayer;
    public float raycastDistance, obstacleDistance, playerDistance;
    public float meleeDistance;
    public float speed;
    public int facingDirection = 1;
    //private bool playerDetected;
    public float DetectionPause;
    public float stateTime;
    public float playerDWaitTime = 1;
    public float chargeTime;
    public float chargeSpeed;
    public float damageAmount;
    public Vector2 knockbackAngle;
    public float knockbackForce;
    public float Health;
    public float MaxHealth = 20;

    #endregion
    #region Unity callbacks
    private void Awake()
    {
        patrolstate = new Patrulha_state(this, "patrol");
        playerDstate = new PlayerD_state(this, "player detected");
        chargeState = new Charge_state(this, "charge");
        meleeAttackState = new AtaqueMelee(this, "meleeAttack");
        damagedState = new DamagedState(this, "damaged");
        deathState = new DeathState(this, "death");

        CurrentState = patrolstate;
        CurrentState.Enter();
    }

    void Start()
    {
        Health = MaxHealth;
    }
    private void Update()
    {
        CurrentState.LogicUpdate();

    }

    // Update is called once per frame
    void FixedUpdate()
    {

        CurrentState.PhysicsUpdate();

    }

    public bool CheckForObstacles()
    {
        RaycastHit2D hit = Physics2D.Raycast(ledgeDetector.position, Vector2.down, raycastDistance, groundlayer);
        RaycastHit2D hitObstacle = Physics2D.Raycast(ledgeDetector.position, facingDirection == 1 ? Vector2.right : Vector2.left, obstacleDistance, obstacleLayer);

        if (hit.collider == null || hitObstacle.collider == true)
        {
            Debug.Log("cade o chão");
            return true;
        }
        else
        {
            return false;
        }
    }
    public bool CheckForPlayer()
    {
        RaycastHit2D hitplayer = Physics2D.Raycast(ledgeDetector.position, facingDirection == 1 ? Vector2.right : Vector2.left, playerDistance, playerLayer);

        if (hitplayer.collider == true)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    public bool CheckForMeleeTarget()
    {
        RaycastHit2D MeleeTarget = Physics2D.Raycast(ledgeDetector.position, facingDirection == 1 ? Vector2.right : Vector2.left, meleeDistance, playerLayer);

        if (MeleeTarget.collider == true)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    #endregion  

    #region Outras funções
    private void OnDrawGizmos()
    {
        Gizmos.DrawRay(ledgeDetector.position, (facingDirection == 1 ? Vector2.right : Vector2.left) * playerDistance);
    }

    public void SwitchState(enemy_state newState)
    {
        CurrentState.Exit();
        CurrentState = newState;
        CurrentState.Enter();
        stateTime = Time.time;
    }

    public void AnimationFinishedTrigger()
    {
        CurrentState.AnimationFinishedTrigger();
    }

    public void AnimationAttackTrigger()
    {
        CurrentState.AnimationAttackTrigger();
    }

    public void Damage(float damageAmount)
    {

    }

    public void Damage(float damageAmount, float KBForce, Vector2 KBAngle)
    {
        damagedState.KBForce = KBForce;
        damagedState.KBAngle = KBAngle;
        Health -= damageAmount;

        if (Health <= 0)
        {
            SwitchState(deathState);
            Destroy(gameObject, 1f);
        }
        else
        {
            SwitchState(damagedState);
        }
    }
    public void Flip()
    {
        facingDirection = -facingDirection;
        transform.Rotate(0, 180, 0);
    }
    #endregion
}
