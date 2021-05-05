using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LoadingLabel : MonoBehaviour
{

    [SerializeField] private TextMeshProUGUI text;
    [SerializeField] private Animator loadingLabelAnimator;

    public void OnPlayButtonClick()
    {
        text.enabled = true;
        loadingLabelAnimator.Play("Loading Label Fade In");
    }

}
