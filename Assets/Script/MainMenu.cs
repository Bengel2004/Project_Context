using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    public static bool inMenu;

    private void OnEnable()
    {
        inMenu = true;
    }

    public void StartGame()
    {
        inMenu = false;
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
