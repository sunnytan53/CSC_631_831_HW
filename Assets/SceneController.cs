using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class SceneController : MonoBehaviour {
    public Camera camera1;
    public Camera camera2;
    public int score = 0;

    void Start() {
        camera1.enabled = true;
        camera2.enabled = false;
    }

    private string cameraText = "Change Camera";
    private string sceneText = "Change Day Night";

    public void updateScore(int gain){
        score += gain;
    }

    void OnGUI()
    {
        if (GUI.Button(new Rect(10, 20, 150, 30), cameraText))
        {
            camera1.enabled = !camera1.enabled;
            camera2.enabled = !camera2.enabled;
        }

        string activeScene = SceneManager.GetActiveScene().name;
        bool isFirstScene = (activeScene == "Game");
        string sceneName2 = isFirstScene ? "GameNight" : "Game";

        if (GUI.Button(new Rect(10, 60, 150, 30), sceneText))
        {
            SceneManager.LoadScene("Scenes/" + sceneName2);
            Debug.Log("sceneName2 is: " + sceneName2);
        }

        GUI.Button(new Rect(10, 100, 150, 30), "Points: " + score.ToString());
        
        /***
        if (GUI.Button(new Rect(150, 150, 150, 40), "Click Tree!"))
        {
            // Perform some action when the button is clicked
            Debug.Log("Button clicked!");
        }
        ***/
    }

}
