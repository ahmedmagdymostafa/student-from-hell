using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class mainmenu : MonoBehaviour {

    public void PlayGame()
    {
        SceneManager.LoadScene("Lecture theatre2");
    }
    public void playtutorial()
    {
        SceneManager.LoadScene("Lecture theatre");
    }
    public void quitmenu()
    {
        Debug.Log("quit!!");
        Application.Quit();
    }
}
