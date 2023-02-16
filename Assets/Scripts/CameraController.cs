using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform carTransform;
    private void FixedUpdate()
    {
        transform.position = new Vector3(carTransform.transform.position.x,transform.position.y, carTransform.transform.position.z);
    }
}
