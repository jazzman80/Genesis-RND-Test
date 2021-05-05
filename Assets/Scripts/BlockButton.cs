using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BlockButton : MonoBehaviour
{
    private Button button;

    private void Start()
    {
        button = gameObject.GetComponent<Button>();
    }

    private IEnumerator ButtonBlock()
    {
        button.interactable = false;
        yield return new WaitForSeconds(1.0f);
        button.interactable = true;
    }

    public void OnBlockEvent()
    {
        StartCoroutine(ButtonBlock());
    }

}
