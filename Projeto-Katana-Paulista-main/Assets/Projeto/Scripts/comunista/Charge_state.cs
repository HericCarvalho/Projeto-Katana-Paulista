using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Charge_state : enemy_state
{
    public Charge_state(Comunista enemy, string animationName) : base(enemy, animationName)
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

        if (Time.time >= enemy.stateTime + enemy.chargeTime)
        {
            if (enemy.CheckForPlayer())
            {
                enemy.SwitchState(enemy.playerDstate);
            }
            else
            {
                enemy.SwitchState(enemy.patrolstate);
            }
        }
        else
        {
            if (enemy.CheckForMeleeTarget())
            {
                enemy.SwitchState(enemy.meleeAttackState);
                Debug.Log ("cade");
            }
            Charge();
        }
    }

    void Charge()
    {
        enemy.rb.velocity = new Vector2(enemy.chargeSpeed * enemy.facingDirection, enemy.rb.velocity.y);
    }
}
