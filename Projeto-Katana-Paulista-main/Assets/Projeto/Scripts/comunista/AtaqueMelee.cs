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
    public override void AnimationAttackTrigger()
    {
        base.AnimationAttackTrigger();
        Collider2D[] hitColliders = Physics2D.OverlapCircleAll(enemy.ledgeDetector.position, enemy.meleeDistance, enemy.damageableLayer);

        foreach (Collider2D hitCollider in hitColliders)
        {
            IDamageable damageable = hitCollider.GetComponent<IDamageable>();
            if (damageable != null)
            {
                hitCollider.GetComponent<Rigidbody2D>().velocity = new Vector2(enemy.knockbackAngle.x * enemy.facingDirection, enemy.knockbackAngle.y) * enemy.knockbackForce;
                damageable.Damage(enemy.damageAmount);
            }
        }

    }

    public override void AnimationFinishedTrigger()
    {
        base.AnimationFinishedTrigger();
        enemy.SwitchState(enemy.patrolstate);

    }
}
