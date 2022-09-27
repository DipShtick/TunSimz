using UnityEngine;

public class Bullet : MonoBehaviour
{

    Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    public Weapon gun;
    // Update is called once per frame
    void Update()
    {
        // Moves bullet each frame
        rb.velocity = transform.right * gun.speedBullet;
    }

}
