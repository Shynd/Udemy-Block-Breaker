using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public void LoadLevel(string name)
    {
        Debug.Log(string.Format("'LoadLevel()' Called with arument: {0}", name));
        Brick.breakableCount = 0;
        SceneManager.LoadScene(name);
    }

    public void LoadNextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void QuitRequest()
    {
        Debug.Log("Quit requested.");

        bool debug = false;
        Debug.Assert(debug = true);
        if (debug)
        {
            Debug.Log("You can't quit while playing in the editor.");
            return;
        }

        Application.Quit();
    }

    public void BrickDestroyedMessage()
    {
        if (Brick.breakableCount <= 0)
        {
            LoadNextLevel();
        }
    }
}