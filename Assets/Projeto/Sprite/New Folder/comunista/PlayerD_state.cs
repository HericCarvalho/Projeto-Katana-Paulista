using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerD_state : enemy_state
{
    public PlayerD_state(Comunista enemy, string animationName) : base(enemy, animationName)
    {

    }

    public override void Enter()
    {
        base.Enter();

        enemy.rb.velocity = Vector2.zero;
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        if (!enemy.CheckForPlayer())
        {
            enemy.SwitchState(enemy.patrolstate);
        }
        else
        {
            if (Time.time >= enemy.stateTime + enemy.playerDWaitTime)
            {
                enemy.SwitchState(enemy.chargeState);
            }
        }

    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}
