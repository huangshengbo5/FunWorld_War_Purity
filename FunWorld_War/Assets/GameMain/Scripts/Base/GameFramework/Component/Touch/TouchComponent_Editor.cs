using System;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Rendering;

public class TouchComponent_Editor : TouchComponent
{
    
    private float doubleTapTimeThreshold = 0.3f;
    private float longPressTimeThreshold = 0.5f;
    private float minPinchDistance = 10f;

    private float lastTapTime;
    private Vector2 lastTapPosition;
    private float touchStartTime;
    private bool isLongPressing;
    private Vector2 touchStartPos;


    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (!IsPointerOverUI())
            {
                HanlderMouseButtonUp();
                GameEntry.Event.Fire(this, TouchClickNotUIEventArgs.Create());
            }
        }
    }

    //是否电击在UI上
    private bool IsPointerOverUI()
    {
        PointerEventData pointerEventData = new PointerEventData(EventSystem.current)
        {
            position = Input.mousePosition
        };
        var results = new List<RaycastResult>();
        EventSystem.current.RaycastAll(pointerEventData, results);
        return results.Count > 0;
    }
    
    private void HanlderMouseButtonUp()
    {
        TriggerSingleTap(Input.mousePosition);
    }
}