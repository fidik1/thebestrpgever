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
    [SerializeField] GameObject spine;

    [SerializeField] private LayerMask obstacles;

    [SerializeField] private float maxDistance;

    private Vector3 startPos;

    private void Start()
    {
        startPos = transform.position;
    }

    private void Update()
    {
        Rotate();
    }

    private void LateUpdate()
    {
        ObstacleReact();
    }

    private void Rotate()
    {
        ga.transform.position = rb.transform.position;
        Vector3 inputHorizontal = new Vector3(0, Input.GetAxis("Mouse X"), 0) * horizontalSensitivity * 100;
        rb.MoveRotation(rb.rotation * Quaternion.Euler(inputHorizontal * Time.fixedDeltaTime));
        inputVertical -= Input.GetAxis("Mouse Y") * verticalSensitivity;
        inputVertical = Mathf.Clamp(inputVertical, -80, 80);
        ga.rotation = Quaternion.Euler(inputVertical, rb.transform.eulerAngles.y, 0);

        spine.transform.rotation = Quaternion.Euler(Mathf.Clamp(inputVertical, -57, 80), spine.transform.eulerAngles.y, spine.transform.eulerAngles.z);
    }

    private void ObstacleReact()
    {
        var distance = Vector3.Distance(transform.position, rb.transform.position);
        RaycastHit hit;
        if (Physics.Raycast(rb.transform.position, transform.position - rb.transform.position, out hit, maxDistance, obstacles))
        {
            transform.position = hit.point;
        }
        else if (distance < maxDistance && !Physics.Raycast(transform.position, -transform.forward, .1f, obstacles))
        {
            transform.localPosition = startPos;
        }
    }
}