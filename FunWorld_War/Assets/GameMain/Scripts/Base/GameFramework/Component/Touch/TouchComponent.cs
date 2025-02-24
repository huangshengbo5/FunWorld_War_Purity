
using System;
using UnityEngine;

public class TouchComponent : MonoBehaviour
{
    public static TouchComponent instance;
    //单击
    public event Action<Vector2> OnSingleTap;

    //双击
    public event Action<Vector2> OnDoubleTap;

    //长按
    public event Action<Vector2> OnLongPressd;

    //双指，缩放
    public event Action<Vector2, float> OnPinch;

    //双指拖动
    public event Action<Vector2> OnTwoFingerDrag;
    

    public TouchComponent Instance()
    {
        if (instance == null)
        {
            instance = this;
        }
        return instance;
    }

    public void TriggerSingleTap(Vector2 position)
    {
        OnSingleTap?.Invoke(position);
    }

    public void TriggerDoubleTap(Vector2 position)
    {
        OnDoubleTap?.Invoke(position);
    }

    public void TriggerLongPressd(Vector2 position)
    {
        OnLongPressd?.Invoke(position);
    }

    public void TriggerPinch(Vector2 position, float pinch)
    {
        OnPinch?.Invoke(position,pinch);
    }

    public void TriggerTwoFingerDrag(Vector2 position)
    {
        OnTwoFingerDrag?.Invoke(position);
    }
}