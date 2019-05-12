using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;// Required when using Event data.

public class draggableBox : MonoBehaviour/*, IPointerDownHandler*/// required interface when using the OnPointerDown method.
{
    private Vector3 screenPoint;
    private Vector3 offset;
    private bool positionChanged;
    public GameObject rotateXClockwise;
    public GameObject rotateXCounterClockwise;
    private int counterDbg;

    // Use this for initialization
    void Start()
    {
        positionChanged = false;
        rotateXClockwise = GameObject.Find("rotateXClockwise");
        rotateXClockwise.SetActive(false);

        rotateXCounterClockwise = GameObject.Find("rotateXCounterClockwise");
        rotateXCounterClockwise.SetActive(false);
        counterDbg = 0;
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(this.gameObject.name + " Was Clicked2.... .");

    }

    //public void OnPointerDown(PointerEventData eventData)
    //{
    //    screenPoint = Camera.main.WorldToScreenPoint(gameObject.transform.position);
    //    offset = gameObject.transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z));
    //    Debug.Log("screenPoint: " + screenPoint + " offset " + offset);
    //}
    
    
    //Do this when the mouse is clicked over the selectable object this script is attached to.
    public void OnMouseDown()
    {
        screenPoint = Camera.main.WorldToScreenPoint(transform.position);
        offset = transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z));
        //Debug.Log("screenPoint: " + screenPoint + " offset " + offset);
    }

    public void OnMouseDrag()
    {
        Vector3 cursorScreenPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z);
        Vector3 cursorPosition = Camera.main.ScreenToWorldPoint(cursorScreenPoint) + offset;
        if (transform.position != cursorPosition)
        {
            transform.position = cursorPosition;
            positionChanged = true;
            rotateXClockwise.SetActive(false);
            rotateXCounterClockwise.SetActive(false);
            //Debug.Log("transform.position : " + transform.position);
        }
        
        //Debug.Log("screenPoint: " + screenPoint + " offset " + offset);

    }
    public void OnMouseUp()
    {
        if (!positionChanged)
        {
            //transform.Rotate(0, 0, 90);
            //Debug.Log("isDragged " + isDragged);          
            Vector3 offset = new Vector3((float)2, (float)-1, 0);
            rotateXClockwise.transform.position = transform.position + offset;
            Debug.Log("activeSelf " + rotateXClockwise.activeSelf + " count " + counterDbg++);
            rotateXClockwise.SetActive(!rotateXClockwise.activeSelf);


            //rotateXCounterClockwise.transform.position = transform.position - offset;
            //rotateXCounterClockwise.SetActive(!rotateXCounterClockwise.active);
        }
        else {
            rotateXClockwise.SetActive(false);
            rotateXCounterClockwise.SetActive(false);
        }
        positionChanged = false;
    }
}
