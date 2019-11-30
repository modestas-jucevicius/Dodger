using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AbilityScript : ScriptableObject
{
    public Sprite sprite;
    public float timer;

    public abstract void Initialize(GameObject obj);
    public abstract void AbilityStart();
    public abstract void AbilityEnd();
}
