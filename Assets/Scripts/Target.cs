using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{

    private void Update()
    {
        transform.Translate(Vector3.forward, Space.Self);
    }

    public void OnLeftArrowClick()
    {
        transform.Rotate(0, -10, 0);
    }

    public void OnRightArrowClick()
    {
        transform.Rotate(0, 10, 0);
    }

}
