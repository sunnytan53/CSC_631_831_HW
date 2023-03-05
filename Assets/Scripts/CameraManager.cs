using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class CameraManager : MonoBehaviour
{
    public Camera camera1;
    public Camera camera2;

    private bool isFollowed = false;

    void Update()
    {
        if (Input.GetKey("escape"))
        {
            SceneManager.LoadScene("Menu");
        }
        // do NOT use GetKey() to avoid pressing
        if (Input.GetKeyDown(KeyCode.E))
        {
            isFollowed = !isFollowed;
            camera1.enabled = !isFollowed;
            camera2.enabled = isFollowed;
        }
    }
}
