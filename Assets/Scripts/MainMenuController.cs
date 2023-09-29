using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    public static MainMenuController instance;
    private void Start()
    {
        instance = this;
    }
    private void Lateupdate()
    {
        PlayGame();
        QUitGame();
    }
    public void PlayGame()
    {
        SceneManager.LoadScene("GameLevel1");
    }
    public void QUitGame()
    {
        Application.Quit();
    }
}
