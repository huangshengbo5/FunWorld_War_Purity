using System;
using System.Drawing;
using Script.Game.Base;
using UnityEngine;

[RequireComponent(typeof(Camera))]
public class Battle_Camera : MonoBehaviour
{
    public float LeftLine;
    public float RighLine;
    public float UpLine;
    public float DownLine;
    private Camera mainCamera;
    private void Start()
    {
        mainCamera = Camera.main;
        GameEntry.Touch.OnSingleTap += HandlerSingleTap;
        GameEntry.Touch.OnSingleFingerDrag += HandlerSingleFingerDrag;
    }

    void HandlerSingleTap(Vector2 position)
    {
        Ray ray = mainCamera.ScreenPointToRay(position);
        RaycastHit hit;
        if (Physics.Raycast(ray,out hit))
        {
            var baseObj = hit.collider.gameObject;
            var Town = baseObj.GetComponent<Town>();
            if (Town)
            {
                Town.OnClick();
            }
            Debug.Log($"hit object:{hit.collider.name}");
        }
    }

    void HandlerSingleFingerDrag(Vector2 direction)
    {
        var cameraPos = mainCamera.transform.position;
        var moveDistance = direction * Time.deltaTime;
        var newPosX = Mathf.Max(LeftLine, Mathf.Min(RighLine, moveDistance.x + cameraPos.x));
        var newPosZ = Mathf.Max(UpLine, Mathf.Min(DownLine, moveDistance.y + cameraPos.z));
        var newPos = new Vector3(newPosX,cameraPos.y,newPosZ);
        //ÒÆ¶¯ÉãÏñ»ú
        mainCamera.transform.position = newPos;
    }
}