using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class NPC : Humanoid
{
    // Start is called before the first frame update
    public override void Awake()
    {
        MaxHP = 50;
        Speed = 5;

        base.Awake();
    }
}
