using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (menuName = "Abilities/SpeedBoostAbility")]
public class SpeedBoostAbility : AbilityScript
{
    public float movementSpeed, defaultSpeed;
    private PlayerMovementControlScript player; 

    public override void Initialize(GameObject obj)
    {
        player = obj.GetComponent<PlayerMovementControlScript>();
        defaultSpeed = player.Speed;
    }

    public override void AbilityStart()
    {
        player.Speed = movementSpeed;
    }
    
    public override void AbilityEnd()
    {
        player.Speed = defaultSpeed;
    }
}
