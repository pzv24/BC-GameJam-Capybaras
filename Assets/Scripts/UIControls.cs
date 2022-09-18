using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIControls : MonoBehaviour
{
    [SerializeField] GameObject _controls;
    [SerializeField] GameObject _showControlsText;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            _controls.SetActive(true);
           
            if (Input.GetKeyDown(KeyCode.S))
            {
                _showControlsText.SetActive(false);
            }
        }
        if (Input.GetKeyDown(KeyCode.H))
        {

            _controls.SetActive(false);
           
            if (Input.GetKeyDown(KeyCode.H))
            {
                _showControlsText.SetActive(true);
            }
        }
       
    }
    public void ResetScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
