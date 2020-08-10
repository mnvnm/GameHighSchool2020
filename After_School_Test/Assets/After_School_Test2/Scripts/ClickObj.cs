using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ClickObj : MonoBehaviour//, IPointerDownHandler
{
    private int clickCount = 0;

    //public void OnPointerDown(PointerEventData eventData)
    //{
    //    clickCount++;
    //    Debug.Log("Click : " + clickCount);
    //    //throw new System.NotImplementedException();
    //}

    //private void OnMouseDown()
    //{
    //    clickCount++;
    //    Debug.Log("Click : " + clickCount);
    //}

    public void OnPointerDownEvent(BaseEventData eventData)
    {
        clickCount++;
        Debug.Log("Click : " + clickCount);       
    }
}
