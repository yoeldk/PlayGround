using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotateXClockwise : MonoBehaviour
{

    public GameObject draggableBox;
    public int clickCounterDbg;

    // Use this for initialization
    void Start()
    {
        clickCounterDbg = 0;
        draggableBox = GameObject.Find("DraggableBox");
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void OnMouseUp()
    {
        //int newRotationX = ((int)draggableBox.transform.rotation.x + 90 ) % 270;
        //draggableBox.transform.Rotate(newRotationX, 0, 0, Space.Self);
        //draggableBox.transform.SetPositionAndRotation(draggableBox.transform.position, new Quaternion())

        Vector3 updatedRotation = draggableBox.transform.eulerAngles;
        updatedRotation.x = Mathf.Round(Mathf.Round(updatedRotation.x + 90) % 360); // range is [-90,0,90,180]
        
        draggableBox.transform.rotation = Quaternion.Euler(updatedRotation);
        //draggableBox.transform.localRotation = Quaternion.Euler(updatedRotation);
        //Debug.Log("updatedRotation.x: " + updatedRotation.x);
    }
    
}
