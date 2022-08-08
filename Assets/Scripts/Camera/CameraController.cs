using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float horizontalSensitivity;
    public float verticalSensitivity;

    [SerializeField] Transform ga;
    float inputVertical;
    float inputHorizontall;
    [SerializeField] Rigidbody rb;

    void Update()
    {
        Rotate();
    }

    void Rotate()
    {
        ga.transform.position = rb.transform.position;
        Vector3 inputHorizontal = new Vector3(0, Input.GetAxis("Mouse X"), 0) * horizontalSensitivity * 100;
        rb.MoveRotation(rb.rotation * Quaternion.Euler(inputHorizontal * Time.fixedDeltaTime));
        inputVertical -= Input.GetAxis("Mouse Y") * verticalSensitivity;
        inputVertical = Mathf.Clamp(inputVertical, -80, 80);
        ga.rotation = Quaternion.Euler(inputVertical, rb.transform.eulerAngles.y, 0);
    }
}
