//using Google.Protobuf.WellKnownTypes;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerControl : MonoBehaviour
{
    private UIManager UI;
    public GameObject GameOverPanel;
   
   
    public Text Score;
    public Text FinalScore;
    public Text Highscore;
    public static int ScoreCount;
    private bool StopGame;
    private float Durat;
    public int Life;
    public Text LifeCount;

    public static int HighScore;

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1;

        Life = 3;                                               //Initialize with value 3
       
        GameOverPanel.SetActive(false);
        Vector3 tmpPos = transform.position;
        tmpPos.x = Mathf.Clamp(tmpPos.x, -1.8f, 1.8f);
        transform.position = tmpPos;

        ScoreCount = 0;
        HighScore = PlayerPrefs.GetInt("Highscore", HighScore);

        UI = GetComponent<UIManager>();
    }

    // Update is called once per frame
    void Update()
    {
        Durat = Time.timeSinceLevelLoad;


        if (Durat > 59.0f)
        {
            StopGame = true;                                        
        }

        Debug.Log(Durat);

        if(StopGame == true || Life <= -5)                      // Condition check
        {
           GameOverPanel.SetActive(true);

           Time.timeScale = 0;
        }
        

        Score.text = "SCORE: " + ScoreCount;

        if (ScoreCount > HighScore)
        {
            HighScore = ScoreCount;
            PlayerPrefs.SetInt("Highscore", HighScore);
        }

        Highscore.text = "HIGHSCORE: " + HighScore;
        FinalScore.text = "YOUR SCORE: " + ScoreCount;
        LifeCount.text = "Lives: " + Life;
    }


   private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Wall"))
        {
            other.gameObject.tag = "Untagged";
            Life--;                                       // Decrement on hitting obstacles
        }

        if (other.gameObject.CompareTag("Score"))
        {

            ScoreCount += 1;
        }
    }


    public void Restart()
    {

        UI.Restar();
    }

   
  
}

