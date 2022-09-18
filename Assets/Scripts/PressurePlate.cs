using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressurePlate : MonoBehaviour
{
    [SerializeField] GameObject _toggableSpeedBoost;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Ball")
        {
            SpeedBoostForce boost = _toggableSpeedBoost.GetComponent<SpeedBoostForce>();
            boost.TurnOn();
        }
    }
}
