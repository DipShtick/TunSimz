using UnityEngine;

public class Bullet : MonoBehaviour
{   
    Rigidbody2D rb;
    Guns _gun;
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        _gun = GetComponent<Guns>();

        FixedUpdate();
    } 

    public void FixedUpdate()
    {
        rb.velocity = rb.position * _gun.BulletSpeed;
    }

    public void Update()
    {
        RaycastHit2D _bulletHit = Physics2D.Raycast(_gun._gunpoint, _gun._bulletTrajectory);

        if (_bulletHit)
        {
            
            switch (_bulletHit.collider.tag)
            {
                
                case "Humanoid":
                 Humanoid _hum = _bulletHit.transform.GetComponent<Humanoid>();
                 _hum.TakeDamage(_gun.Damage);
                 Destroy(gameObject);
                break;
                
                default:
                 Destroy(gameObject);
                break;
            }

            Debug.DrawRay(transform.position, transform.forward, Color.cyan, 8f);
            Debug.Log(_bulletHit.collider.name);
        }
    }
}
