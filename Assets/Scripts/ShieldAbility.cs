using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Abilities/ShieldAbility")]
public class ShieldAbility : AbilityScript
{
    private PlayerCollision collision;

    public override void Initialize(GameObject obj)
    {
        collision = obj.GetComponent<PlayerCollision>();
    }

    public override void AbilityStart()
    {
        collision.shieldActive = true;
    }

    public override void AbilityEnd()
    {
        collision.shieldActive = false;
    }
}
