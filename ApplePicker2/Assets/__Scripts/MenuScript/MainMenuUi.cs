using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuUi : MonoBehaviour
{
    public void StartTheGame()
    {
        SceneManager.LoadScene("Scene0");
    }

    public void ExitFromTheGame()
    {
        Application.Quit();
    }
}
