using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameFinished : MonoBehaviour
{
    public GameObject screenParent;
    public GameObject scoreParent;

    public UnityEngine.UI.Text scoreText;

    public UnityEngine.UI.Text loseText;
    // Start is called before the first frame update
    void Start()
    {
        screenParent.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ShowNonHighscore(){

        screenParent.SetActive(true);
        scoreParent.SetActive(false);

        Animator animator = GetComponent<Animator>();

        if(animator){
            animator.Play("GameFinishedShow");
        }
    }

    public void ShowHighscore(int score){

        screenParent.SetActive(true);
        loseText.enabled = false;

        scoreText.text = score.ToString();
        
        Animator animator = GetComponent<Animator>();

        if(animator){
            animator.Play("GameFinishedShow");
        }
    }

    public void OnContinueClicked(){
        UnityEngine.SceneManagement.SceneManager.LoadScene("levelSelect");
    }
}
