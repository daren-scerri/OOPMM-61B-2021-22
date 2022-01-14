using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

    [SerializeField] Text playerScoreText;

    [SerializeField] Text livesText;

    [SerializeField] Text hscoreText;

    [SerializeField] GameObject playerPrefab;

    public static GameManager _instance;

    void Awake()
    {

        //SINGLETON PATTERN - ensure you have only one instance of a class

        if (_instance == null)
        {
            _instance = this;
        }
        else if (_instance != this)
        {
            Destroy(this.gameObject);
        }

        SceneManager.sceneLoaded += OnSceneLoaded;
        DontDestroyOnLoad(this.gameObject);
      
    }




    // Use this for initialization
    void Start () {
        GameData.GameScore = 0;
        GameData.Lives = 3;
        GameData.HighScore = 0;
        GetComponent<SaveLoadManager>().LoadMyData();
        playerScoreText.text = "Score: " + GameData.GameScore.ToString();
        livesText.text = "Lives: " + GameData.Lives.ToString();
        hscoreText.text = "HScore: " + GameData.HighScore.ToString();
    }

    public void OnEnemyDie()
    {
      
        GameData.GameScore++;
        playerScoreText.text = "Score: " + GameData.GameScore.ToString();
        GetComponent<SaveLoadManager>().SaveMyData();
    }

    public void OnFixedEnemyDie()
    {

        SceneManager.LoadScene("Win");
    }

    public void OnPlayerDie()
    {
        GameData.Lives--;
        livesText.text = "Lives: " + GameData.Lives.ToString();
        if (GameData.Lives > 0)
        {
            Instantiate(playerPrefab, new Vector3(-5f, 0f, 0f), Quaternion.identity);
            GetComponent<SaveLoadManager>().SaveMyData();
        }
        else         
            SceneManager.LoadScene("GameOver");
   

        

    }
    // Update is called once per frame
    void Update () {

        

    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (scene.name == "GameOver"  || scene.name == "Win")
        {
            print("Score = " + GameData.GameScore.ToString());
            Text myscoretext = GameObject.Find("Scoretext").GetComponent<Text>();
            myscoretext.text = "Score : " + GameData.GameScore.ToString();
           
            //HIGH SCORE CHECK, CHANGE IF NEED BE AND DISPLAY
            if (GameData.GameScore > GameData.HighScore) GameData.HighScore = GameData.GameScore;  //CHECK IF HIGH SCORE NEEDS UPDATE
            Text myhscoretext = GameObject.Find("Highscoretext").GetComponent<Text>();
            myhscoretext.text = "High Score : " + GameData.HighScore.ToString(); 
            
            GameData.GameScore = 0;
            GameData.Lives = 3;
            GetComponent<SaveLoadManager>().SaveMyData();

        }
    }
}
