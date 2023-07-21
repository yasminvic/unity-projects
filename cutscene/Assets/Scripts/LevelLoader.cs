using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    [Header("Animation")]
    [SerializeField]
    private Animator animator;

    [Header("Delay")]
    [SerializeField]
    private float delayAnimation;

    [Header("Scene")]
    [SerializeField]
    private string nameScene;

    public void LoadScene()
    {
        StartCoroutine(LoadNextScene());
    }

    IEnumerator LoadNextScene()
    {
        //iniciar animação
        animator.SetTrigger("Start");

        //wait
        yield return new WaitForSeconds(delayAnimation);

        //load scene
        SceneManager.LoadScene(nameScene);

    }
}
