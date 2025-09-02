using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneMove : MonoBehaviour
{
    public GameObject escButton;

    private void Start()
    {
        escButton.SetActive(false);

    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))   
        {
            bool isActive = escButton.activeSelf;
            escButton.SetActive(!isActive);
        }
    }

    public void MoveScene(int scene_number)
    {
        SceneManager.LoadScene(scene_number);
    }

}
