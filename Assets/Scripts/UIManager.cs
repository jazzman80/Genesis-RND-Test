using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{

    [SerializeField] private GameObject loadingText;
    [SerializeField] private GameObject loadingBackground;

    private void Start()
    {
        StartCoroutine(HideLoadingMenu());
    }

    private IEnumerator HideLoadingMenu()
    {
        yield return new WaitForSeconds(1.0f);
        loadingBackground.SetActive(false);
        loadingText.SetActive(false);
    }

}
