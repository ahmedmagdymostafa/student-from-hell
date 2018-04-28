using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

    private bool ended = false;
    public GameObject win;
    public void endgame()
    {
        if (!ended)
        {
            ended = true;
            win.SetActive(true);
            Invoke("rebuild", 2f);
        }

    }
    public void rebuild()
    {
        SceneManager.LoadScene("menu");
    }
}
