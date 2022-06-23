using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonsController : MonoBehaviour
{
    public void ExitGame()
    {
        Application.Quit();
    }
    public void ToStartMenu()
    {
        SceneManager.LoadScene(0);
    }
}
