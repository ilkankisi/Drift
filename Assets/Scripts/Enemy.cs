using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEditor.Build.Content;
using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.UI;
using UnityEditor;

public class Enemy : MonoBehaviour
{
    public GameObject car1;
    public GameObject car2;
    public GameObject car3;
    public GameObject car4;
    public GameObject player;
    public bool isCar1Active=true;
    public bool isCar2Active=true;
    public bool isCar3Active=true;
    public bool isCar4Active=true;
    public bool isPlayerActive=true;

    public GameObject parashute;
    public float pullPowerValue;
    List<int> distanceList= new List<int>();
    private int[] posibleDistance= new int[4] {40,35,25,15};
    bool isFinish=false;
    public Text succesInfo;
    public GameObject popup;
    private void FixedUpdate()
    {
        if(!isFinish)
        {
            DetectEnemy();
            areCarsActive();
        }
    }
    public void DetectEnemy()
    {
        distanceList.Add((int)Mathf.Abs(Vector3.Distance(transform.position, car1.transform.position)));
        distanceList.Add((int)Mathf.Abs(Vector3.Distance(transform.position, car2.transform.position)));
        distanceList.Add((int)Mathf.Abs(Vector3.Distance(transform.position, car3.transform.position)));
        distanceList.Add((int)Mathf.Abs(Vector3.Distance(transform.position, car4.transform.position)));
        distanceList.Add((int)Mathf.Abs(Vector3.Distance(transform.position, parashute.transform.position))); 

        if (distanceList[0] == distanceList.Min() &&  !parashute.activeSelf && isCar1Active &&
            posibleDistance[PlatformController.Instance.platformDistanceLevel]> Vector3.Distance(transform.position, new Vector3(0, transform.position.y, 0)))
        {
            gameObject.transform.LookAt(car1.transform);
            GetComponent<Rigidbody>().AddForce((car1.transform.position - transform.position).normalized * pullPowerValue, ForceMode.Impulse);
        }
        else if (distanceList[1] == distanceList.Min() && !parashute.activeSelf && isCar2Active &&
            posibleDistance[PlatformController.Instance.platformDistanceLevel] > Vector3.Distance(transform.position, new Vector3(0, transform.position.y, 0)))
        {
            gameObject.transform.LookAt(car2.transform);
            GetComponent<Rigidbody>().AddForce((car2.transform.position - transform.position).normalized * pullPowerValue, ForceMode.Impulse);
        }
        else if (distanceList[2] == distanceList.Min() && !parashute.activeSelf && isCar3Active &&
            posibleDistance[PlatformController.Instance.platformDistanceLevel] > Vector3.Distance(transform.position, new Vector3(0, transform.position.y, 0)))
        {
            gameObject.transform.LookAt(car3.transform);
            GetComponent<Rigidbody>().AddForce((car3.transform.position - transform.position).normalized * pullPowerValue, ForceMode.Impulse);
        }
        else if (distanceList[3] == distanceList.Min() && !parashute.activeSelf && isCar4Active &&
            posibleDistance[PlatformController.Instance.platformDistanceLevel] > Vector3.Distance(transform.position, new Vector3(0, transform.position.y, 0)))
        {
            gameObject.transform.LookAt(car4.transform);
            GetComponent<Rigidbody>().AddForce((car4.transform.position - transform.position).normalized * pullPowerValue, ForceMode.Impulse);
        }
        else if (distanceList[4] == distanceList.Min() && parashute.activeSelf)
        {
            gameObject.transform.LookAt(parashute.transform);
            GetComponent<Rigidbody>().AddForce((parashute.transform.position - transform.position).normalized * pullPowerValue, ForceMode.Impulse);
        }
        else
        {
            gameObject.transform.LookAt(new Vector3(0,0,0));
            GetComponent<Rigidbody>().AddForce((new Vector3(0, transform.position.y, 0) - transform.position).normalized * pullPowerValue, ForceMode.Impulse);
        }
        distanceList.Clear();
    }
    public void areCarsActive()
    {
        if (car1.transform.position.y < -1 && isCar1Active)
        {
            isCar1Active = false;
        }
        if (car2.transform.position.y < -1 && isCar2Active)
        {
            isCar2Active = false;
        }
        if (car3.transform.position.y < -1 && isCar3Active)
        {
            isCar3Active = false;
        }
        if (car4.transform.position.y < -1 && isCar4Active)
        {
            isCar4Active = false;
        }
        if (player.transform.position.y < -1 && isPlayerActive)
        {
            isPlayerActive = false;
        }

        if(!isPlayerActive)
        {
            isFinish = true;
            succesInfo.GetComponent<Text>().text = ("You Lost");
            popup.SetActive(true);
        }

        if (isPlayerActive && !isCar1Active && !isCar2Active && !isCar3Active && !isCar4Active)
        {
            //player.transform.GetChild(player.transform.childCount - 1).GetComponent<MeshRenderer>().material = Resources.Load<Material>("Images/Materials/smile");
            isFinish = true;
            succesInfo.GetComponent<Text>().text = ("You Won");
            popup.SetActive(true);
        }
        else if (!isPlayerActive && isCar1Active && !isCar2Active && !isCar3Active && !isCar4Active)
        {
            //car2.transform.GetChild(player.transform.childCount - 1).GetComponent<MeshRenderer>().material = Resources.Load<Material>("Images/Materials/smile");
            isFinish = true;
            succesInfo.GetComponent<Text>().text = ("You Lost");
            popup.SetActive(true);
        }
        else if (!isPlayerActive && !isCar1Active && isCar2Active && !isCar3Active && !isCar4Active)
        {
            //car3.transform.GetChild(player.transform.childCount - 1).GetComponent<MeshRenderer>().material = Resources.Load<Material>("Images/Materials/smile");
            isFinish = true;
            succesInfo.GetComponent<Text>().text = ("You Lost");
            popup.SetActive(true);
        }
        else if (!isPlayerActive && !isCar1Active && !isCar2Active && isCar3Active && !isCar4Active)
        {
            //car4.transform.GetChild(player.transform.childCount - 1).GetComponent<MeshRenderer>().material = Resources.Load<Material>("Images/Materials/smile");
            isFinish = true;
            succesInfo.GetComponent<Text>().text= ("You Lost");
            GameObject.Find("winPopup").SetActive(true);
        }
        else if (!isPlayerActive && !isCar1Active && !isCar2Active && !isCar3Active && isCar4Active)
        {
            player.transform.GetChild(player.transform.childCount - 1).GetComponent<MeshRenderer>().material = Resources.Load<Material>("Images/Materials/smile");
            isFinish = true;
            succesInfo.GetComponent<TextMeshPro>().text  = ("You Lost");
            popup.SetActive(true);
        }
    }

}
