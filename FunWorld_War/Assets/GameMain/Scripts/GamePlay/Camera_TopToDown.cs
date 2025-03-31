using System;
using UnityEngine;

[RequireComponent(typeof(Camera))]
public class Camera_TopToDown : MonoBehaviour
{
    private Camera camera;
    private void Start()
    {
        camera = GetComponent<Camera>();
        if (camera == null)
        {
            camera = this.gameObject.AddComponent<Camera>();
        }
    }

    private void LateUpdate()
    {
        
    }
}