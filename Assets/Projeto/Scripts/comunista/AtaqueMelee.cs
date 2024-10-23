using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AtaqueMelee : enemy_state
{
    public AtaqueMelee(Comunista enemy, string animationName) : base(enemy, animationName)
    {

    }

    public override void Enter()
    {
        base.Enter();
        Collider2D[] hitColliders = Physics2D.OverlapCircleAll(enemy.ledgeDetector.position, enemy.meleeDistance, enemy.damageableLayer);

        foreach (Collider2D hitCollider in hitColliders)
        {
            IDamageable damageable = hitCollider.GetComponent<IDamageable>();
            if (damageable != null) 
            {
                hitCollider.GetComponent<Rigidbody2D>  ().velocity= new Vector2 (enemy.knockbackAngle.x * enemy.facingDirection, enemy.knockbackAngle.y) * enemy.knockbackForce;
                damageable.Damage(enemy.damageAmount);
            }
        }

        enemy.SwitchState(enemy.patrolstate);

    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}
