using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{ 
    [SerializeField] private float _velocityThreshold = 10f;
    [SerializeField] private float _minVelocity = 5f;

    private Rigidbody _rb;
    private bool _isKillable = false;
    private void Awake()
    {
        _rb = GetComponent<Rigidbody>();
    }
    private void Update()
    {
        if (_rb.velocity.magnitude > _minVelocity)
        {
            _isKillable = true;
        }
        if (_rb.velocity.magnitude < _velocityThreshold && _isKillable)
        {
            Destroy(gameObject);
        }
    }
}
