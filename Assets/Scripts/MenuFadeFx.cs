using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuFadeFx : MonoBehaviour
{

    [SerializeField] private Animator menuFadeFxAnimator;
    [SerializeField] private Image backgroundScreen;

    public void OnPlayButtonClick()
    {
        backgroundScreen.enabled = true;
        menuFadeFxAnimator.Play("Menu Fade FX");
    }

}
