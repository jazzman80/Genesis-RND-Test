using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    private CharacterController body;

    private bool playerRotatingLeft;
    private bool playerRotatingRight;
    [SerializeField] private float runSpeed;
    [SerializeField] private float rotationSpeed;
    [SerializeField] private float rotationTime;
    private float verticalSpeed;
    private float gravity;


    private void Start()
    {
        body = gameObject.GetComponent<CharacterController>();
        playerRotatingLeft = false;
        playerRotatingRight = false;
        gravity = 9.8f;
    }

    private void FixedUpdate()
    {
        body.Move(transform.forward * runSpeed * Time.fixedDeltaTime);

        if (playerRotatingLeft) transform.Rotate(0, -rotationSpeed * Time.fixedDeltaTime, 0);
        if (playerRotatingRight) transform.Rotate(0, rotationSpeed * Time.fixedDeltaTime, 0);

        if (body.isGrounded) verticalSpeed = 0;
        else
        {
            verticalSpeed -= gravity * Time.fixedDeltaTime;
            body.Move(transform.up * verticalSpeed * Time.fixedDeltaTime);
        }
    }

    public void OnLeftArrowClick()
    {
        StopAllCoroutines();
        StartCoroutine(RotatingLeft());
    }

    public void OnRightArrowClick()
    {
        StopAllCoroutines();
        StartCoroutine(RotatingRight());
    }

    private IEnumerator RotatingLeft()
    {
        playerRotatingLeft = true;
        yield return new WaitForSeconds(rotationTime);
        playerRotatingLeft = false;
    }

    private IEnumerator RotatingRight()
    {
        playerRotatingRight = true;
        yield return new WaitForSeconds(rotationTime);
        playerRotatingRight = false;
    }

}
