using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Tracker : MonoBehaviour
{
    [SerializeField]
    public GameObject Player;
    public int scoreValue; 
    // Start is called before the first frame update
    void Start()
    {
        scoreValue = 0;
        Player = GameObject.Find("Player");
    }

    public Text HStext;
    public GameObject PlayerHP;
    public Text ScoreUI;
    public Sprite spriteDead;

    // Update is called once per frame
    void Update()
    {
        /* Displays score & highscore
        ScoreUI.text = scoreValue.ToString();
        HStext.text = PlayerPrefs.GetInt("Weed").ToString();

        //Display retry button after dead
        //** if (Player.activeInHierarchy == false)
        {
            retry.SetActive(true);
            PlayerHP.GetComponent<Image>().sprite = spriteDead;
        }
        */
    }
    public void AddScore(int bonus) 
    {
        //Score & highscore calculations
        scoreValue = scoreValue + bonus;
        if (scoreValue > PlayerPrefs.GetInt("Weed")) 
        {
            PlayerPrefs.SetInt("Weed", scoreValue);
        }
        
    }

    public GameObject retry;
    // Reloads the scene after clicking retry button
    public void Replay() 
    {
        SceneManager.LoadScene(0);
        Time.timeScale = 1;
        retry.SetActive(false);
    }
    
}
