using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamagedState : enemy_state
{
    public float KBForce;
    public Vector2 KBAngle;
    public DamagedState(Comunista enemy, string animationName) : base(enemy, animationName)
    {

    }

    public override void AnimationAttackTrigger()
    {
        base.AnimationAttackTrigger();
    }

    public override void AnimationFinishedTrigger()
    {
        base.AnimationFinishedTrigger();
    }

    public override void Enter()
    {
        base.Enter();
        ApplyKnockback();
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
    private void ApplyKnockback()
    {
        enemy.rb.velocity = KBAngle * KBForce;
    }
}
