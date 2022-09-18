using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedBoostForce : MonoBehaviour
{
    [SerializeField] private float force = 10;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay(Collider other)
    {
        Rigidbody rigidbody = other.GetComponent<Rigidbody>();
        rigidbody.AddForce(transform.forward * force, ForceMode.Acceleration);
    }
}
