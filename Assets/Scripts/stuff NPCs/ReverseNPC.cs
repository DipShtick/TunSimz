using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class ReverseNPC : MonoBehaviour
{

    [SerializeField] private float HP;
    public float MaxHP;
    public GameObject HealthBarUI;
    public Slider slider;
    public float Speed;
    private float distance;
    private Rigidbody2D rb;
    private bool coll;
    public GameObject Player;
    public GameObject me;
    public GameObject Weapon;
    private Vector2 direction;
    public int KB = 20;
    public GameObject weapon;

    public bool isfleeing = false;

    // SigmaConseil


    // Destroy bullet when hit
    void OnTriggerEnter2D(Collider2D col) 
    {
        TakeDamage();
        Destroy(col.gameObject);
    }

    // Knockback Initiation
    void OnCollisionEnter2D(Collision2D col){
        if(col.gameObject.CompareTag("Player"))
        {
            coll = true;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        //Sets HP to MaxHP
        HP = MaxHP;
        Player = GameObject.Find("Player");
        //Starts it at 0
        slider.value = 0;
        
    }

    // Update is called once per frame


    //Knockback function
    IEnumerator Knock()
    {
        Player.GetComponent<Rigidbody2D>().AddForce(direction * KB);
        yield return new WaitForSeconds(0.2f);
        coll = false;
        isfleeing = true;
        StartCoroutine(Escape());
    }

    IEnumerator Escape()
    {
        if(isfleeing)
        {
            rb.velocity = -direction * Speed * 2;
        }
        yield return new WaitForSeconds(0.9f);
        isfleeing = false;
    }


    void Update()
    {
        // AI stuff
        direction = (Player.transform.position - transform.position).normalized;
        //transform.position = Vector2.MoveTowards(this.transform.position, Player.transform.position, Speed * Time.deltaTime);
        if(!isfleeing){
            rb.velocity = direction * Speed;
        }

        //float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        //transform.rotation = Quaternion.Euler(Vector3.forward * angle);

        // Repeats Knockback function
        if(coll)
        {
            StartCoroutine(Knock());
        }
        
        //
        if (HP < MaxHP)
        {
            HealthBarUI.SetActive(true); 
        }

        if (HP <= 0) 
        {
            Destroy(gameObject);
        }

    }
    

    // To calculate for UI
    float CalculateHP() 
    {
        return HP/MaxHP;
    }

    // To give the illusion of something satisfying happening
    IEnumerator blood()
    {
        yield return new WaitForSeconds (0.1f);
        me.GetComponent<SpriteRenderer>().color = new Color (1,1,1);
    }

    // TAKEL TRI7A TMOT SA7BI WELD OMI
    float TakeDamage() 
    {
        slider.value = 1 - CalculateHP();
        me.GetComponent<SpriteRenderer>().color = new Color (1,0,0);
        StartCoroutine (blood ());
        return HP = HP - 10;
    }
}
