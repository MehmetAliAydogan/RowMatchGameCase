using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadLevel : MonoBehaviour
{
    // Start is called before the first frame update
    private string level_name;

    public void Load(string level){
        level_name = level;
        PlayerPrefs.SetString("level_name", level_name);
    }

    public void LoadScene(){
        SceneManager.LoadScene("Level1");
    }

}
