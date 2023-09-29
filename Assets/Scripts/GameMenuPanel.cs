using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameMenuPanel : MonoBehaviour
{
    public void resetGame()
    {
        Time.timeScale = 1.0f;
        SceneManager.LoadScene("GameLevel1");
    }
}
