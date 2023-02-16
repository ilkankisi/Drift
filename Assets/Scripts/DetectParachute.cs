using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectParachute : MonoBehaviour
{
    public static DetectParachute Instance { get; private set; }
    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.name.Contains("CarDetect"))
        {
            other.gameObject.transform.GetChild(1).GetComponent<TurnAround>().enableTurn = true;
            gameObject.SetActive(false);
        }

    }
    public void setRandomPosForParashute()
    {
        gameObject.SetActive(true);
        float x = Random.Range(-25.0f, 25.0f);
        float z = Random.Range(-25.0f, 25.0f);
        gameObject.transform.position= new Vector3(x,25, z);
    }
    public void setParashute()
    {
        gameObject.GetComponent<Rigidbody>().isKinematic = true;
        setRandomPosForParashute();
        gameObject.GetComponent<Rigidbody>().isKinematic = false;
    }
}
