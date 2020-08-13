using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovementScript : MonoBehaviour
{
    public Transform target;
    public float smooth = 5.0f;
    public Vector3 offset = new Vector3(0, 2);

    private void FixedUpdate()
    {
        transform.position = Vector3.Lerp(transform.position, target.position + offset, smooth);
    }
}
