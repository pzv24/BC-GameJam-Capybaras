using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class BallLauncher : MonoBehaviour
{
    [SerializeField] private GameObject _ball;
    [SerializeField] private GameObject _arrow;

    [Header("Arrow Data")]
    [SerializeField] private float _turnSpeed = 5f;
    [SerializeField] private float halfAngleRange = 60;

    public Camera mainCamera;
    private Vector3 _mouseWorldLocation;
    private Vector2 _mousePosition;
    private Rigidbody _rb;
    private Vector3 _currentRotation;
    private Quaternion currentRotation => transform.rotation;


    private void Awake()
    {
        _rb = GetComponent<Rigidbody>();
    }
    public void OnRotateLeft(InputValue value)
    {
        Debug.Log("A"); 
    }

    private void FixedUpdate()
    {
        transform.Rotate(_currentRotation);
    }

}
