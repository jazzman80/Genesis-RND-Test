using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{

    [SerializeField] private GameObject fadeFx;
    [SerializeField] private Animator loadingLabelAnimator;
    [SerializeField] private Animator fadeFxAnimator;

    private void Start()
    {
        DontDestroyOnLoad(gameObject);
        DontDestroyOnLoad(fadeFx);
        SceneManager.LoadScene("Start Scene");
    }

    public void OnPlayButtonClick()
    {
        StartCoroutine(LoadingScene("Main Scene"));
    }

    public void OnStartSceneButtonClick()
    {
        StartCoroutine(LoadingScene("Start Scene"));
    }

    private IEnumerator LoadingMainScene()
    {
        yield return new WaitForSeconds(1.0f);
        SceneManager.LoadScene("Main Scene");
    }

    private IEnumerator LoadingScene(string sceneName)
    {
        fadeFx.SetActive(true);
        fadeFxAnimator.Play("Fade Out");
        loadingLabelAnimator.Play("Loading Label Fade In");
        yield return new WaitForSeconds(1.0f);
        SceneManager.LoadScene(sceneName);
        fadeFxAnimator.Play("Fade In");
        loadingLabelAnimator.Play("Loading Label Fade Out");
        yield return new WaitForSeconds(1.0f);
        fadeFx.SetActive(false);
    }

}
