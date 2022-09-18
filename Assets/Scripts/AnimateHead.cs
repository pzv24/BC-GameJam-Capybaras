using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimateHead : MonoBehaviour
{
    private Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            animator.SetTrigger("IsShooting");
        }

        if (Input.GetKeyUp(KeyCode.Space))
        {
            animator.ResetTrigger("IsShooting");
        }
    }
}
