using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Abilities/TeleportAbility")]
public class TeleportAbility : AbilityScript
{
    public int teleportDistance;
    private PlayerMovementControlScript playerMovement;
    private Vector3 position = Vector3.zero;
    private GameObject player;

    public override void Initialize(GameObject obj)
    {
        playerMovement = obj.GetComponent<PlayerMovementControlScript>();
        player = obj;
    }

    public override void AbilityStart()
    {
        position.x = playerMovement.getInputs().x*teleportDistance;
        position.z = playerMovement.getInputs().z*teleportDistance;
        player.transform.position = player.transform.position + new Vector3(position.x, 0, position.z);
        
    }

    public override void AbilityEnd()
    {
    }
}
