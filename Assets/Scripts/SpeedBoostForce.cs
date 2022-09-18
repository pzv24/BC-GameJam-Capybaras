using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedBoostForce : MonoBehaviour
{
    [SerializeField] private float force = 10;

    [SerializeField] private bool _isActive = false;

    private void OnTriggerStay(Collider other)
    {
        if (!_isActive) { return; }
        Rigidbody rigidbody = other.GetComponent<Rigidbody>();
        rigidbody.AddForce(transform.forward * force, ForceMode.Acceleration);
    }

    public void TurnOn()
    {
        _isActive = true;
    }
}
