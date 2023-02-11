using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Marker : MonoBehaviour
{
    public Camera camera;
    private void FixedUpdate()
    {
        if (Input.GetMouseButton(0))
        {
            Vector3 mousePosition = camera.ScreenToWorldPoint(Input.mousePosition);
            transform.position= new Vector3(mousePosition.x, transform.position.y, mousePosition.z);
        }
    }
}
