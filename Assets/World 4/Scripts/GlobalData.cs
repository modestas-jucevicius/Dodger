using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GlobalData
{
    public static GameMode gameMode;
    public static TutorialStage tutorialStage;
    public static string tutorialMessage
    {
        get
        {
            switch (tutorialStage)
            {
                case TutorialStage.Movement: return "Use joystick below to move your character";
                case TutorialStage.AvoidingEnemies: return "Avoid your enemies to survive";
                case TutorialStage.Powers: return "Press icons on the left to activate your powers";
            }
            return "Nu maladiec";
        }
    }
    

    public enum GameMode
    {
        Tutorial,
        Play
    }

    public enum TutorialStage
    {
        Movement, AvoidingEnemies, Powers
    }

}
    
