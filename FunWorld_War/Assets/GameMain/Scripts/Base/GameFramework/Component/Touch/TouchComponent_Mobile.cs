using UnityEngine;

public class TouchComponent_Mobile : TouchComponent
{
    private float doubleTapTimeThreshold = 0.3f;
    private float longPressTimeThreshold = 0.5f;
    private float minPinchDistance = 10f;

    private float lastTapTime;
    private Vector2 lastTapPosition;
    private float touchStartTime;
    private bool isLongPressing;
    private Vector2 touchStartPos;

    private void Update()
    {
        if (Input.touchCount == 1 )
        {
            HandlerSingleFingerTouch();
        }
        else if (Input.touchCount == 2)
        {
            HandlerTowFingerTouch();
        }
    }

    private void HandlerSingleFingerTouch()
    {
        Touch touch = Input.GetTouch(0);
        switch (touch.phase)
        {
            case TouchPhase.Began:
                touchStartTime = Time.time;
                touchStartPos = touch.position;
                isLongPressing = true;
                break;
            case TouchPhase.Ended:
                if (isLongPressing && Time.time - touchStartTime >= longPressTimeThreshold)
                {
                    TriggerLongPressd(touch.position);
                }
                else
                {
                    HandleTap(touch.position);
                }
                break;
        }
    }
    
    private void HandleTap(Vector2 position)
    {
        if (Time.time - lastTapTime < doubleTapTimeThreshold && Vector2.Distance(position,lastTapPosition) < 100f)
        {
            TriggerDoubleTap(position);
            lastTapTime = 0;
        }
        else
        {
            TriggerSingleTap(position);
            lastTapTime = Time.time;
            lastTapPosition = position;
        }
    }

    private void HandlerTowFingerTouch()
    {
        Touch touch1 = Input.GetTouch(0);
        Touch touch2 = Input.GetTouch(1);
        Vector2 touchCenter = (touch1.position + touch2.position) / 2;
        float currentDistance = Vector2.Distance(touch1.position,touch2.position);
        float previousDistance = Vector2.Distance(
            touch1.position - touch1.deltaPosition,
            touch2.position = touch2.deltaPosition
            );

        float pinchDelta = currentDistance - previousDistance;
        if (Mathf.Abs(pinchDelta) > minPinchDistance)
        {
            TriggerPinch(touchCenter,pinchDelta);
        }

        Vector2 touch1Delta = touch1.deltaPosition;
        Vector2 touch2Delta = touch2.deltaPosition;
        if (Vector2.Dot(touch1Delta.normalized,touch2Delta.normalized) > 0.8f)
        {
            Vector2 averageDelta = (touch1Delta + touch2Delta) / 2;
            TriggerTwoFingerDrag(averageDelta);
        }
    }
}