using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainScreen : MonoBehaviour
{

    [SerializeField] private Animator mainScreenAnimator;

    public void OnSettingsButtonClick()
    {
        mainScreenAnimator.Play("Main Screen Slide Left");
    }

    public void OnBackButtonClick()
    {
        mainScreenAnimator.Play("Main Screen Slide Right");
    }

}
