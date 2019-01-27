using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour
{

    public void GoToMainScene()
    {
        SceneManager.LoadScene("MainGame");
    }

    public void GoToMenuScene()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void GoToOptionsScene()
    {
        SceneManager.LoadScene("OptionsMenu");
    }
}