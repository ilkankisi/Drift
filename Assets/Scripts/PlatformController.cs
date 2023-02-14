using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformController : MonoBehaviour
{
    public Transform area;
    private void Start()
    {
        StartCoroutine(DropPartOfPlatform());
    }
    private IEnumerator DropPartOfPlatform()
    {
        yield return new WaitForSeconds(1.0f);
        for (int i = 0; i < 30; i++)
        {
            yield return new WaitForSeconds(0.2f);
            area.transform.GetChild(i).GetComponent<Rigidbody>().isKinematic = false;
        }
        yield return new WaitForSeconds(5.0f);
        for (int i = 30; i < 55; i++)
        {
            yield return new WaitForSeconds(0.2f);
            area.transform.GetChild(i).GetComponent<Rigidbody>().isKinematic = false;
        }
        yield return new WaitForSeconds(5.0f);
        for (int i = 55; i < 75; i++)
        {
            yield return new WaitForSeconds(0.2f);
            area.transform.GetChild(i).GetComponent<Rigidbody>().isKinematic = false;
        }
        yield return new WaitForSeconds(5.0f);
        for (int i = 75; i < 85; i++)
        {
            yield return new WaitForSeconds(0.2f);
            area.transform.GetChild(i).GetComponent<Rigidbody>().isKinematic = false;
        }
        yield return new WaitForSeconds(5.0f);
        for (int i = 85; i < 100; i++)
        {
            yield return new WaitForSeconds(0.2f);
            area.transform.GetChild(i).GetComponent<Rigidbody>().isKinematic = false;
        }
    }
}
