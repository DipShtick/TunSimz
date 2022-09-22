using UnityEngine;

public class Bullet : MonoBehaviour
{

    Rigidbody2D rb;
    public float Speed;
    

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Speed = 8f;
    }

    public Wapoon gun;
    // Update is called once per frame
    void Update()
    {
        
    }

}
