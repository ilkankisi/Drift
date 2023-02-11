using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
public class FollowMarker : MonoBehaviour
{
    public GameObject marker;
    public GameObject ballGo;
    public Rigidbody rb;
    public float massValue;
    public float pullPowerValue;

    void FixedUpdate()
    {
        rb.mass=massValue;
        FollowTouch();
    }
    public void FollowTouch()
    {
        if (Mathf.Abs(Vector3.Distance(marker.transform.position, transform.position)) > 5 && Input.GetMouseButton(0))
        {
            rb.AddForce(transform.forward * pullPowerValue, ForceMode.Impulse);
        }
    }
}
