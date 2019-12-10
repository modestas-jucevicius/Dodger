using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOffArena : MonoBehaviour
{
    private bool firstEnemyNotExitedArena = true;
    public UnityEngine.UI.Text tutorialMessage;

    void OnTriggerExit(Collider other)
    {
        if (GlobalData.gameMode == GlobalData.GameMode.Tutorial)
        {
            print("Pirmas ifas praejo");
            if (firstEnemyNotExitedArena)
            {
                print("Antras ifas praejo");
                GlobalData.tutorialStage = GlobalData.TutorialStage.Powers;
                tutorialMessage.text = GlobalData.tutorialMessage;
                firstEnemyNotExitedArena = false;
            }
        }
        Destroy(other.gameObject);
    }
}
