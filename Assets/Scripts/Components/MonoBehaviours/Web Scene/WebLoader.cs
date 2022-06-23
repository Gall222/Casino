using UnityEngine;
using System.Collections;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;

public class WebLoader : MonoBehaviour
{
    public string url;
    void Start()
    {
        StartCoroutine(checkInternetConnection());
    }
    IEnumerator checkInternetConnection()
    {
        var www = new UnityWebRequest(url);
        yield return www.SendWebRequest();
        if (www.error != null)
        {
            //если нет соединения, запустить игру
            StartGame();
        }
        else
        {
            //иначе, открыть ссылку
            Application.OpenURL(url);
        }
    }
    public void StartGame()
    {
        SceneManager.LoadScene(2);
    }
}
