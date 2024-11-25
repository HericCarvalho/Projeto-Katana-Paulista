using System.Collections;
using System.Collections.Generic;
using UnityEditor.Tilemaps;
using UnityEngine;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class Patrulha_state : enemy_state
{
    public Patrulha_state(Comunista enemy, string animationName) : base(enemy, animationName)
    {

    }

    public override void Enter()
    {
        base.Enter();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        if (enemy.CheckForPlayer())
        {
            enemy.SwitchState(enemy.playerDstate);
        }
        if (enemy.CheckForObstacles())
        {
            enemy.Flip();
        }

    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();


        if (enemy.facingDirection == 1)
        {
            enemy.rb.velocity = new Vector2(enemy.speed, enemy.rb.velocity.y);
        }
        else
        {
            enemy.rb.velocity = new Vector2(-enemy.speed, enemy.rb.velocity.y);

        }
    }
    
}
