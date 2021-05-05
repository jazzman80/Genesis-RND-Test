using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Transform target;
    private float smoothTime = 0.3F;
    private Vector3 velocity = Vector3.zero;

    private void Update()
    {
        Vector3 targetPosition = target.TransformVector(new Vector3(0, 5, -10));
        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothTime);
    }
}
