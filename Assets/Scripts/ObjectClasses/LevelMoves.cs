using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelMoves : Level
{

    public int numMoves;

    private int movesUsed = 0;
    // Start is called before the first frame update
    void Start()
    {
        //sfxManager.PlaySFX(SoundClip.Start);
        type = LevelType.MOVES;
        manager_UI.SetScore(currentScore);
        manager_UI.SetHighScore(highscore);
        manager_UI.SetRemainingMoves(numMoves);
        Debug.Log("Num Moves: " + numMoves);
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override void OnMove()
    {
        movesUsed++;
        sfxManager.PlaySFX(SoundClip.Move);
        Debug.Log("Remaining Moves: " +(numMoves - movesUsed));
        manager_UI.SetRemainingMoves(numMoves - movesUsed);

        if(movesUsed == numMoves){
            GameFinished();
        }
    }
}
