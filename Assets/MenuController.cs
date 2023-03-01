using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class MenuController : MonoBehaviour {
    
    private string sceneText = "Back To Game";
    private string sceneName1 = "Game";
    // private string sceneName2 = "Menu";

    void OnGUI()
    {
        if (GUI.Button(new Rect(10, 20, 150, 30), sceneText))
        {
            SceneManager.LoadScene("Scenes/" + sceneName1);
        }

        /***
        if (GUI.Button(new Rect(150, 150, 150, 40), "Click Tree!"))
        {
            // Perform some action when the button is clicked
            Debug.Log("Button clicked!");
        }
        ***/
    }

}
