using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEditor.Build.Content;
using UnityEngine;
using UnityEngine.Animations;

public class Enemy : MonoBehaviour
{
    public GameObject car1;
    public GameObject car2;
    public GameObject car3;
    public GameObject car4;
    public GameObject parashute;
    public float pullPowerValue;
    public List<int> distanceList= new List<int>();
    private void FixedUpdate()
    {
        DetectEnemy();
    }
    public void DetectEnemy()
    {
        distanceList.Add((int)Mathf.Abs(Vector3.Distance(transform.position, car1.transform.position)));
        distanceList.Add((int)Mathf.Abs(Vector3.Distance(transform.position, car2.transform.position)));
        distanceList.Add((int)Mathf.Abs(Vector3.Distance(transform.position, car3.transform.position)));
        distanceList.Add((int)Mathf.Abs(Vector3.Distance(transform.position, car4.transform.position)));
        distanceList.Add((int)Mathf.Abs(Vector3.Distance(transform.position, parashute.transform.position)));

        if (distanceList[0] == distanceList.Min())
        {
            gameObject.transform.LookAt(car1.transform);
            GetComponent<Rigidbody>().AddForce((car1.transform.position - transform.position).normalized * pullPowerValue, ForceMode.Impulse);
        }
        else if (distanceList[1] == distanceList.Min())
        {
            gameObject.transform.LookAt(car2.transform);
            GetComponent<Rigidbody>().AddForce((car2.transform.position - transform.position).normalized * pullPowerValue, ForceMode.Impulse);
        }
        else if (distanceList[2] == distanceList.Min())
        {
            gameObject.transform.LookAt(car3.transform);
            GetComponent<Rigidbody>().AddForce((car3.transform.position - transform.position).normalized * pullPowerValue, ForceMode.Impulse);
        }
        else if (distanceList[3] == distanceList.Min())
        {
            gameObject.transform.LookAt(car4.transform);
            GetComponent<Rigidbody>().AddForce((car4.transform.position - transform.position).normalized * pullPowerValue, ForceMode.Impulse);
        }
        else if (distanceList[4] == distanceList.Min() && parashute.activeSelf)
        {
            gameObject.transform.LookAt(parashute.transform);
            GetComponent<Rigidbody>().AddForce((parashute.transform.position - transform.position).normalized * pullPowerValue, ForceMode.Impulse);
        }
        distanceList.Clear();
    }
}
