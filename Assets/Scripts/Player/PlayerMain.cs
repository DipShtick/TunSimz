using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMain : Humanoid
{
    private PlayerMovement _plyMove;
    public override void Awake()
    {
        MaxHP = 100;
        Speed = 7;
        _plyMove = gameObject.GetComponent<PlayerMovement>();

        base.Awake();
    }

    public override void Die()
    {
        gameObject.SetActive(false);
    }

    public override void Attack(Vector3 _target, Vector3 _myPos)
    {
        base.Attack(_plyMove._myTarget, _plyMove._mePos);
    }
}



