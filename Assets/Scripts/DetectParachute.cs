using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectParachute : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.name.Contains("CarDetect"))
        {
            switch (other.gameObject.transform.parent.GetSiblingIndex())
            {
                case 0:
                    other.gameObject.transform.GetChild(1).GetComponent<TurnAround>().enableTurn = true;
                    Debug.Log("you");
                    break;
                case 1:
                    Debug.Log("first");
                    break;
                case 2:
                    Debug.Log("second");
                    break;
                case 3:
                    Debug.Log("third");
                    break;
                default:
                    Debug.Log("fourth");
                    break;
            }
            gameObject.SetActive(false);
        }

    }
    private void FixedUpdate()
    {
        DropParachute();
    }
    public void DropParachute()
    {
        if (gameObject.transform.position.y < 10)
        {
            gameObject.GetComponent<Rigidbody>().isKinematic = true;
        }
    }
}
