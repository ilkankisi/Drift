using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PlatformController : MonoBehaviour
{
    public static PlatformController Instance { get; private set; }
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
    public Transform area;
    int[] times = new int[6] {0,30,55,75,85,99};
    public int platformDistanceLevel = 0;
    private void Start()
    {
        StartCoroutine(DropPartOfPlatform());
    }
    private IEnumerator DropPartOfPlatform()
    {
        for (int i = 0; i < 5; i++)
        {
            if(i!=0 && i!=4)
            {
                platformDistanceLevel = i;
            }
            DetectParachute.Instance.setParashute();
            yield return new WaitForSeconds(5.0f);
            for (int j =times[i]; j < times[i+1]; j++)
            {
                yield return new WaitForSeconds(0.2f);
                area.transform.GetChild(j).GetComponent<Rigidbody>().isKinematic = false;
            }
        }
    }
}
