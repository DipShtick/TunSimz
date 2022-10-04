using UnityEngine;
using UnityEngine.InputSystem;

public class Pistol : MonoBehaviour
{
    [SerializeField] private Transform firepoint;
    [SerializeField] private GameObject bullet;

    // Start is called before the first frame update
    void Start()
    {
        // Searches for corresponding needs
        bullet = GameObject.Find("pis_bullet");
        cam = Camera.main;
        rb = gameObject.GetComponent<Rigidbody2D>();
    }

    public Camera cam;
    Vector3 mousePos;
    // Update is called once per frame
    void Update()
    {
        mousePos = Mouse.current.position.ReadValue();
        Vector3 lookDir = mousePos - transform.position;
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg;
        //transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        rb.rotation = angle;
        rb.position = Vector2.right;
    }
    
    private InputAction look;
    public Rigidbody2D rb;

    // Changes rotation according to the mouse position
    void FixedUpdate()
    {
        
    }

    // Input script
    /*Controls mouse;
    private void Awake()
    {
        mouse = new Controls();
    }
    private void OnEnable()
    {
        look.Enable();
    }

    private void OnDisable()
    {
        look.Disable();
    }  
    */
}
