using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class NPC : MonoBehaviour
{
    
    [SerializeField]
    private float HP;
    public float MaxHP;
    public GameObject HealthBarUI;
    public GameManager karen;
    public float Speed;
    private float distance;
    private Rigidbody2D rb;
    public bool coll;
    public GameObject Player;
    public GameObject Weapon;
    private Vector2 direction;
    private Vector2 dir;
    public int KB;
    public GameObject weapon;
    public bool isfleeing;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        //Sets HP to MaxHP
        HP = MaxHP;
        //Needs this to run other code
        Player = GameObject.Find("Player");
        karen = GameObject.Find("YassinStal").GetComponent<GameManager>();
        //Starts HP bar at 0
        slider.value = 0;
        HealthBarUI.SetActive(false);
        KB = 20;
        isfleeing = false;
    }

    // Knockback Initiation
    void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.CompareTag("Player"))
        {
            coll = true;
        }    
    }

    //Knockback function
    IEnumerator Knock()
    {
        Player.GetComponent<Rigidbody2D>().AddForce(direction * KB);
        yield return new WaitForSeconds(0.2f);
        coll = false;
        isfleeing = true;
        StartCoroutine(Escape());
    }

        // when hit BY a bullet, destroy it
    void OnTriggerEnter2D(Collider2D col) 
    {
        TakeDamage();
        Destroy(col.gameObject);
    }

    //When he hits, he runs away like a frére he is.
    IEnumerator Escape()
    {
        if(isfleeing)
        {
            rb.velocity = -direction * Speed * 2;
        }
        yield return new WaitForSeconds(0.9f);
        isfleeing = false;
    }

    // Update is called once per frame
    void Update()
    {
        // AI stuff
        direction = (Player.transform.position - transform.position).normalized;
        if(!isfleeing){
            rb.velocity = (direction) * Speed;
        }

        // Repeats Knockback function
        if(coll)
        {
            StartCoroutine(Knock());
        }
        
        //When hit, display the hit
        if (HP < MaxHP)
        {
            HealthBarUI.SetActive(true); 
        }

        //Score calculation then ded
        if (HP <= 0) 
        {
            karen.AddScore(100);
            Destroy(gameObject);

        }
    }

    // To give the illusion of something satisfying happening
    IEnumerator blood()
    {
        yield return new WaitForSeconds (0.1f);
        gameObject.GetComponent<SpriteRenderer>().color = new Color (1,1,1);
    }

    // To calculate for UI
    float CalculateHP() 
    {
        return HP/MaxHP;
    }

    public Slider slider;
    // TAKEL TRI7A TMOT SA7BI WELD OMI
    float TakeDamage() 
    {
        slider.value = 1 - CalculateHP();
        gameObject.GetComponent<SpriteRenderer>().color = new Color (1,0,0);
        StartCoroutine (blood ());
        return HP = HP - 10;
    }
}
