using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Win : MonoBehaviour
{
    public GameObject _winUI;
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Ball")
        {
           _winUI.SetActive(true);
        }
    }
}
