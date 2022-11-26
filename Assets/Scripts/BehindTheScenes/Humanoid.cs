using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Humanoid : MonoBehaviour
{
    //Before you, dear reader a GLORIOUS dictionay with all values that you can imagine
    public int MaxHP;
    public int HP;
    public int Speed;

    public string Firstname;
    

    public virtual void Awake()
    {
        HP = MaxHP;
        _guns = GetComponent<Guns>();
    }

    private Guns _guns;
    public virtual void Attack(Vector3 _target, Vector3 _myPos)
    {
        _guns.Shoot(_target, _myPos);
    }

    //When hit, take damage
    public void TakeDamage(int amount)
    {
        HP =- amount;
        StartCoroutine(ManHit());
        if (HP <= 0)
        {
            Die();
        }
    }

    //When you get hit, this function will indicate it by turning it red
    private IEnumerator ManHit()
    {
        yield return new WaitForSeconds(0.2f);
        gameObject.GetComponent<SpriteRenderer>().color = new Color (1,1,1);
    }

    //Death function
    public virtual void Die()
    {
        Destroy(gameObject);
    }

}
