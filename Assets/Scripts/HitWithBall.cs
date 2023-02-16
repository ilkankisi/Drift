using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitWithBall : MonoBehaviour
{
    public float hitTime = 3.0f;
    public GameObject car;
    bool isForce = false; 
    private void OnTriggerEnter(Collider other)
    {
        if(other.name.Contains("MainCarAndCharacterWithWheelAnim"))
        {
            isForce = true;
            car = other.gameObject;
            if(car.transform.parent.name != "CarDetect")
            {
                car.transform.parent.gameObject.GetComponent<Enemy>().pullPowerValue = 0;
            }
            else
            {
                car.transform.parent.gameObject.GetComponent<FollowMarker>().pullPowerValue = 0;
            }
        }
        
    }
    private void FixedUpdate()
    {
        if (isForce)
        {
            StartCoroutine(Hit());
        }
    }
    public IEnumerator Hit()
    {
       GetComponent<Rigidbody>().AddForce((car.transform.position - transform.position).normalized * 200, ForceMode.Impulse);
       yield return new WaitForSeconds(hitTime);

        if (car.transform.parent.name != "CarDetect")
        {
            car.transform.parent.gameObject.GetComponent<Enemy>().pullPowerValue = 20;
        }
        else
        {
            car.transform.parent.gameObject.GetComponent<FollowMarker>().pullPowerValue = 40;
        }
       isForce = false;
    }
}
