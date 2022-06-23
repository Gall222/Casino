using Components;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AgreeMenu : MonoBehaviour
{
    [SerializeField] Swicher agreeSwitcher;
    [SerializeField] GameObject agreeMenu;
    [SerializeField] GameObject policyTextMenu;

    public void ShowPolicyMenu(bool isMenuOn)
    {
        policyTextMenu.SetActive(isMenuOn);
        agreeMenu.SetActive(!isMenuOn);
        
    }

    public void StartGame()
    {
        if (agreeSwitcher.IsOn)
        {
            SceneManager.LoadScene(1);
        }
    }


}
