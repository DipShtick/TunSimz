using System.Collections;
using UnityEngine;
public class Weapon : MonoBehaviour
{
    // VALUES

    //Damage
    public float damagePistol = Random.Range(8f,12f);
    public float damageFist = Random.Range(2f,5f);
    public float explosionDamage;
    //Range
    public float rangeExplosion;
    public float rangePistol = 50f;
    public float rangeFist;
    //Firerate
    public float firerateFist;
    public float fireratePistol = 2f;
    //Speed
    public float speedBullet = 50f;
}
