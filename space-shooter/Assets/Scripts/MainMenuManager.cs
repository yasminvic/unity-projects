using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{

    [SerializeField]
    public string NameScene;

    public void Play()
    {
        SceneManager.LoadScene(NameScene);
    }

    public void ShowCredits()
    {

    }

    public void Quit()
    {
        Application.Quit();
    }
}
