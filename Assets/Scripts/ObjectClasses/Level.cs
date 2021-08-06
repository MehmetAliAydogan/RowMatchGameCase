using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour
{
   protected LevelType type;

   public LevelType Type{
       get { return type;}
   }

    public Grid grid;
    public UIManager manager_UI;

    public SFXManager sfxManager;
    public int highscore;
    protected int currentScore;

    void Start(){
        manager_UI.SetScore(currentScore);
        manager_UI.SetHighScore(highscore);
    }
    public virtual void GameFinished()
    {
        sfxManager.PlaySFX(SoundClip.GameFinished);
        Debug.Log("Game Finished!");
        manager_UI.OnGameFinished(currentScore);
        grid.GameFinished();
    }

    public virtual void OnMove(){
        Debug.Log("On move");
    }

    public virtual void OnItemMatched(Item item){
        //Update score
        sfxManager.PlaySFX(SoundClip.Match);
        currentScore += item.ColoredItemComponent.Score;
        Debug.Log("Score: " + currentScore);
        manager_UI.SetScore(currentScore);
    }

}
