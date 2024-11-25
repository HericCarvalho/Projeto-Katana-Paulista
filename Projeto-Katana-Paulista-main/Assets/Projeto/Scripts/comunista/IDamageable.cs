using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public interface IDamageable
{
    void Damage(float damageAmount);

    void Damage(float damageAmount, float KBForce, Vector2 KBAngle);


}
