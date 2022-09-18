using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move3D : MonoBehaviour
{
    private Camera _mainCamera;
    private float _CameraZDistance;

    [Header("Object rotation")]
    [SerializeField] private Vector3 _rotation;
    [SerializeField] private float _speed;


    void Start()
    {
        _mainCamera = Camera.main;
        _CameraZDistance =
         _mainCamera.WorldToScreenPoint(transform.position).z;
    }
    private void Update()
    {
       
    }

    void OnMouseDrag ()
    {
        Vector3 ScreenPosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, _CameraZDistance);
        Vector3 NewWorldPosition = _mainCamera.ScreenToWorldPoint(ScreenPosition);
        transform.position = NewWorldPosition;
        if (Input.GetKeyDown(KeyCode.Q)) _rotation = Vector3.up;
        else if (Input.GetKeyDown(KeyCode.E)) _rotation = -Vector3.up;
        else _rotation = Vector3.zero;
        transform.Rotate(_rotation * _speed * Time.deltaTime);


    }
}
