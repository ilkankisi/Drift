using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnAround : MonoBehaviour
{
    public int rotateSpeed=835;
    public bool enableTurn = false;
    private void FixedUpdate()
    {
        TurnBall();
    }
    public void TurnBall()
    {
        if (enableTurn)
        {
            transform.Rotate(new Vector3(0, rotateSpeed, 0) * Time.deltaTime);
            StartCoroutine(Wait());
        }
    }

    private IEnumerator Wait()
    {
        yield return new WaitForSeconds(3.0f);
        enableTurn = false;
    }
}
