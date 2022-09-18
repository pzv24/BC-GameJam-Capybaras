using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class BallLauncher : MonoBehaviour
{
    [Header("Plug In Values")]
    [SerializeField] private GameObject _ball;
    [SerializeField] private GameObject _arrow;
    [SerializeField] private Image _arrowImage;

    [Header("Launcher")]
    [SerializeField] private float _turnSpeed = 5f;
    //[SerializeField] private float halfAngleRange = 70;
    [SerializeField] private float _forceBarCharge = 0.05f;
    [SerializeField] private float _forceMultiplier = 100;
    [SerializeField] private float _incrementInterval = 0.05f;

    private Vector3 _rotationDifferential;
    private float _forceCoef;
    private bool _isChargeing;
    private bool _canTurn = true;
    public void OnRotateLeft(InputValue value)
    {
        if (!_canTurn) { return; }
        _rotationDifferential = new Vector3(0, -value.Get<float>() * _turnSpeed, 0);
    }

    public void OnRotateRight(InputValue value)
    {
        if (!_canTurn) { return; }
        _rotationDifferential = new Vector3(0, value.Get<float>() * _turnSpeed, 0);
    }

    IEnumerator ChargeMeter()
    {
        while (true)
        {
            bool goingUp = true;
            while (goingUp)
            {
                _isChargeing = true;
                goingUp = CountUp();
                if (_forceCoef > 1f) { goingUp = false; }
                Debug.Log(_forceCoef);
                yield return new WaitForSeconds(_incrementInterval);
                _isChargeing = false;
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
        ballRB.AddForce(transform.forward *_forceCoef * _forceMultiplier);

    }


    private void Update()
    {
        _arrowImage.fillAmount = _forceCoef;
        if (Input.GetKeyDown(KeyCode.Space) && _isChargeing == false)
        {
            _rotationDifferential = Vector3.zero;
            _canTurn = false;
            Debug.Log("Charging");
            StartCoroutine(ChargeMeter());
        }

        if (Input.GetKeyUp(KeyCode.Space))
        {
            _isChargeing = false;
            StopAllCoroutines();
            LaunchBall();
            _forceCoef = 0;
            _canTurn = true;
        }

        transform.Rotate(_rotationDifferential * Time.deltaTime);
    }
}
