using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move3D : MonoBehaviour
{
    private Camera _mainCamera;
    private float _CameraZDistance;
    

    void Start ()
    {
        _mainCamera = Camera.main;
        _CameraZDistance =
         _mainCamera.WorldToScreenPoint(transform.position).z;
    }


    void OnMouseDrag ()
    {
        Vector3 ScreenPosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, _CameraZDistance);
        Vector3 NewWorldPosition = _mainCamera.ScreenToWorldPoint(ScreenPosition);
        transform.position = NewWorldPosition;
    }
}
