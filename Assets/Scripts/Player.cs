using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    [SerializeField]
    public float speed;
    public float MaxHP;
    public float HP;
    public GameObject HealthBarUI;
    public Slider slide;

    // Start is called before the first frame update
    void Start()
    {
        MaxHP = 100f;
        HP = MaxHP;
        isdead = false;
        speed = 7.5f;
        slide.value = 0;
        HealthBarUI.SetActive(true);
        invincible = false;
    }

    //Input System
    public Controls control;
    private InputAction moveInput;
    private InputAction fireInput;
    private InputAction interact;
    private void Awake()
    {
        control = new Controls();
    }

    private void OnEnable()
    {
        moveInput = control.Player.Move;
        moveInput.Enable();

        fireInput = control.Player.Fire;
        fireInput.Enable();
    }

    private void OnDisable()
    {
        moveInput.Disable();
        fireInput.Disable();
    }


    // Update is called once per frame
    Vector2 moveDirection;
    public bool isdead;
    void Update()
    {
        // LE movement input.
        moveDirection = moveInput.ReadValue<Vector2>(); 

        // HP = 0 --> dies.
        if (HP <= 0) 
        {
            isdead = true;
            if (isdead = !false) 
            {
                gameObject.SetActive(false);
                Time.timeScale = 0;
            } 
        }
    }

    //Input translates to movement per realtime second.
    public Rigidbody2D rb;
    void FixedUpdate() 
    {
        rb.velocity = new Vector2(moveDirection.x * speed, moveDirection.y * speed) ;
    }

    //Attack function
    public void Attack()
    {
        Debug.Log("FIRE!!!!!!!!!");
    }   

    // GET Damaged function
    public bool coll;
    void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.CompareTag("NPC"))
        {
            coll = true;
            if (coll = !false)
            {
                StartCoroutine(TakeDamage());
            }
            
        }
    }

    // Calculates HP for the UI to turn it into a number between 0 and 1
    private bool invincible;
    float CalculateHP() 
    {
        return HP/MaxHP;
    }

    // Deal Damage function
    IEnumerator TakeDamage() 
    {
        if (!invincible) 
        {
            slide.value = 1 - CalculateHP();
            gameObject.GetComponent<SpriteRenderer>().color = new Color (1,0,0);
            StartCoroutine (blood ());
            HP = HP - 10;
            invincible = true;

        }
        
        yield return new WaitForSeconds(0.7f);
        invincible = false;

    }

    // When hit, change color
    IEnumerator blood()
    {
        yield return new WaitForSeconds (0.2f);
        gameObject.GetComponent<SpriteRenderer>().color = new Color (1,1,1);
        coll = false;
    }
}



