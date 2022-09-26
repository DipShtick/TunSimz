using UnityEngine;

public class Bullet : MonoBehaviour
{

    Rigidbody2D rb;
    public float speed;
    

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        speed = 8f;
    }

    public Weapon gun;
    // Update is called once per frame
    void Update()
    {
        rb.velocity = transform.right * speed;
    }

}
