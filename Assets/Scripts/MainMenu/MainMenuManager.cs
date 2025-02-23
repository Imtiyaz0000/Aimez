using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{

    public GameObject mainMenu;
    public GameObject selectionMenu;

    public void PlayGame()
    {
        mainMenu.SetActive(false);
        selectionMenu.SetActive(true);
    }

    public void DummyTarget()
    {
        SceneManager.LoadScene("MainScene");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
