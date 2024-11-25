using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy_state
{
    protected Comunista enemy;
    protected string animationName;

    public enemy_state(Comunista enemy, string animationName)
    {
        this.enemy = enemy;
        this.animationName = animationName;
    }
    public virtual void Enter()
    {
        enemy.anim.SetBool(animationName, true);
    }
    public virtual void Exit()
    {
        enemy.anim.SetBool(animationName, false);
    }
    public virtual void LogicUpdate()  //substitu~ção do Update
    {

    }
    public virtual void PhysicsUpdate()    //substituiçõa do Fixed update
    {

    }
    public virtual void AnimationFinishedTrigger()
    {
        
    }

    public virtual void AnimationAttackTrigger()
    {

    }
}
