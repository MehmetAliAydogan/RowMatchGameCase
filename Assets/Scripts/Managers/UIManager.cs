using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{

    public Level level;

    public GameFinished gameFinished;
    public UnityEngine.UI.Text remainingText;
    public UnityEngine.UI.Text HighscoreText;
    public UnityEngine.UI.Text ScoreText;
    void Start(){
        
    }

    public void SetScore(int score){

        ScoreText.text = score.ToString();
    }

    public void SetHighScore(int highscore){

        HighscoreText.text = highscore.ToString();
    }

    public void SetRemainingMoves(int remaining){

        remainingText.text = remaining.ToString();
    }

    public void OnGameFinished(int score){
        //Burada highsocrea göre show or nonshow hihgscore
        //if(score > PlayerPrefs.SetInt())
        gameFinished.ShowHighscore(score);
    }

}
