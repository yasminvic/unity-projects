using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{

    [SerializeField]
    private string NameScene;



    public void Jogar()
    {
        //rodar uma scene
        SceneManager.LoadScene(NameScene);
                                //aceita como argumento o nome da scene ou a camada em que está
    }

    public void ShowCredits()
    {

    }

    public void Quit()
    {
        Application.Quit();
    }
}
