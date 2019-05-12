using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boxMovement : MonoBehaviour
{
    //private float xPos;
    //float timeToGo;
    int lastSecond;

    // Use this for initialization
    void Start()
    {
        //timeToGo = Time.fixedTime + 0.0f;
        lastSecond = 0;
        //  xPos = -0.2f;
        //StartCoroutine(waiter());

    }

    IEnumerator waiter()
    {
        float currPosX = transform.localPosition.x;
        currPosX += 0.02f;
        if (currPosX >= 0.5){
            currPosX = 0;
        }
        transform.localPosition = new Vector3(currPosX, transform.localPosition.y, transform.localPosition.z);
        yield return new WaitForSeconds(0.5f);
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        int currSecond = (int)Time.fixedTime;
        if (currSecond > lastSecond)
        {
            float currPosX = transform.localPosition.x;
            currPosX += 0.02f;
            if (currPosX >= 0.5)
            {
                currPosX = -0.5f;
            }
            transform.localPosition = new Vector3(currPosX, transform.localPosition.y, transform.localPosition.z);
            //Debug.Log("currSecond: " + currSecond + " lastSecond " + lastSecond);
        }
        lastSecond = currSecond;
        //yield return new WaitForSeconds(1.f);
    }
}
