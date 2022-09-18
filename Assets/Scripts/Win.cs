using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Win : MonoBehaviour
{
    [SerializeField] AudioSource audioSource;
    [SerializeField] AudioClip winSound;
    public GameObject _winUI;
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Ball")
        {
           _winUI.SetActive(true);
        }
        audioSource.clip = winSound;
        audioSource.Play();
    }
}
