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
    [SerializeField] private float halfAngleRange = 70;
    [SerializeField] private float _forceBarCharge = 0.05f;
    [SerializeField] private float _forceMultiplier = 100;

    public Camera mainCamera;
    private Vector3 _mouseWorldLocation;
    private Vector2 _mousePosition;
    private Rigidbody _rb;
    private Vector3 _rotationDifferential;
    private float _forceCoef;
    private float _incrementInterval = 0.1f;
    private bool _isChargeing;

    Quaternion targetRotation;
    private Quaternion currentRotation => transform.rotation;


    private void Awake()
    {
        _rb = GetComponent<Rigidbody>();
    }
    public void OnRotateLeft(InputValue value)
    {
        _rotationDifferential = new Vector3(0, -value.Get<float>() * _turnSpeed, 0);
    }

    public void OnRotateRight(InputValue value)
    {
         _rotationDifferential = new Vector3(0, value.Get<float>() * _turnSpeed, 0);
    }

    IEnumerator ChargeMeter()
    {
        while (true)
        {
            bool goingUp = true;
            while (goingUp)
            {
                goingUp = CountUp();
                if (_forceCoef > 1f) { goingUp = false; }
                Debug.Log(_forceCoef);
                yield return new WaitForSeconds(_incrementInterval);
            }
            while (!goingUp)
            {
                goingUp = CountDown();
                if (_forceCoef < 0f) { goingUp = true; }
                Debug.Log(_forceCoef);
                yield return new WaitForSeconds(_incrementInterval);
            }
        }
    }

    private bool CountUp()
    {
        _forceCoef += _forceBarCharge;
        return true;
    }
    private bool CountDown()
    {
        _forceCoef -= _forceBarCharge;
        return false;
    }

    private void LaunchBall()
    {
        GameObject ball = Instantiate(_ball, transform.position, transform.rotation);
        Rigidbody ballRB = ball.GetComponent<Rigidbody>();
        ballRB.AddForce(transform.forward *_forceBarCharge * _forceMultiplier);

    }


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("Charging");
            StartCoroutine(ChargeMeter());
        }

        if (Input.GetKeyUp(KeyCode.Space))
        {
            StopAllCoroutines();
            LaunchBall();
        }

        transform.Rotate(_rotationDifferential * Time.deltaTime);
        Debug.Log(_rotationDifferential);
    }
}
