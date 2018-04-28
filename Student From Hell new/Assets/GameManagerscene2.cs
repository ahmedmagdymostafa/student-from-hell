using UnityEngine;
using UnityEngine.SceneManagement;
public class GameManagerscene2 : MonoBehaviour {
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
        scoresc.scoreValue = 0;
        SceneManager.LoadScene("menu");
    }
}
