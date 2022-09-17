using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedBoostImpulse : MonoBehaviour
{
    [SerializeField] private float impulse = 20;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        Rigidbody rigidbody = other.GetComponent<Rigidbody>();
        rigidbody.AddForce(transform.forward * impulse, ForceMode.Impulse);
    }
}
