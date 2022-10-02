using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    public GameObject Player;
    public int killme; 
    // Start is called before the first frame update
    void Start()
    {
        killme = 0;
        Player = GameObject.Find("Player");
    }

    public GameObject retry;
    public Text HStext;
    public GameObject pHP;
    public Text ScoreUI;
    public Sprite dood;

    // Update is called once per frame
    void Update()
    {
        //Displays score & highscore
        ScoreUI.text = killme.ToString();
        HStext.text = PlayerPrefs.GetInt("Weed").ToString();

        //Display retry button after dead
        if (Player.activeInHierarchy == false)
        {
            retry.SetActive(true);
            pHP.GetComponent<Image>().sprite = dood;
        }
    }
    public void AddScore(int bonus) 
    {
        //Score & highscore calculations
        killme = killme + bonus;
        if (killme > PlayerPrefs.GetInt("Weed")) 
        {
            PlayerPrefs.SetInt("Weed", killme);
        }
        
    }

    // Reloads the scene after clicking retry button
    public void Replay() 
    {
        SceneManager.LoadScene(0);
        Time.timeScale = 1;
        retry.SetActive(false);
    }

    //Attack
    public float damagePistol;
    public float damageFist;
    public float explosionDamage;
    //Weapon Range
    public float rangeExplosion;
    public float rangePistol;
    public float rangeFist;
    //Attack Speed
    public float firerateFist;
    public float fireratePistol;
    //Character speed
    public float speedSoldier;
    public float speedFrere;
    public float speedCop;
    public float speedDrugDealer;
    public float speedRusher;
    //Consequences
    public float knockback;
    //Stats
    public float deaths;
    public float totalDamageDealt;
    public float totalDamageTaken;
    //Uncategorised
}
