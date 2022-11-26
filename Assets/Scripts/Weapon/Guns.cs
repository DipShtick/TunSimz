using System.Collections;
using UnityEngine;

public class Guns : MonoBehaviour
{
    public float Firerate, BulletsFired, BulletSpeed, KB, Recoil;
    public int ReloadingTime, Accuracy, Magsize, MaxAmno, Damage;

    public Vector3 _gunpoint, _bulletTrajectory;



    public virtual void Awake()
    {
        Firerate = 0.5f;
        BulletSpeed = 7f;
    }

    
    public GameObject _bullet;
    public virtual void Shoot(Vector3 _targetPos, Vector3 _shooterPos)
    {
        RaycastHit2D _bulletPath = Physics2D.Raycast(_shooterPos, _targetPos);
        _gunpoint = _shooterPos;
        _bulletTrajectory = _targetPos;

        if (_bulletPath)
        {  
            Debug.DrawRay(_shooterPos, _targetPos, Color.red);
            if(!_isFiring)
            {
                StartCoroutine(ShootBullet());
            }
            else
            {
                Debug.Log("cooldown");
            }   
        }    
    }

    public bool _isFiring;
    public IEnumerator ShootBullet()
    {
        if(!_isFiring)
        {
            yield return new WaitForFixedUpdate();
            Instantiate(_bullet, _gunpoint, Quaternion.identity);
            _isFiring = true;
        }

        yield return new WaitForSeconds(Firerate);
        _isFiring = false;
    }
}
