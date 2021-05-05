using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingsScreen : MonoBehaviour
{

    [SerializeField] private Animator settingsScreenAnimator;

    public void OnSettingsButtonClick()
    {
        settingsScreenAnimator.Play("Settings Screen Slide Left");
    }

    public void OnBackButtonClick()
    {
        settingsScreenAnimator.Play("Settings Screen Slide Right");
    }

}
