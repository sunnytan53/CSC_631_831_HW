
using UnityEngine;

//using https://www.youtube.com/watch?v=m9hj9PdO328

public class lightCycle : MonoBehaviour
{
    public Light directionalLight;

    [SerializeField, Range(0, 24)] private float timeOfDay;

    public Gradient AmbientColor;
    public Gradient DirectionalColor;
    public Gradient FogColor;


    // Update is called once per frame
    void Update()
    {
        if (Application.isPlaying)
        {
            //(Replace with a reference to the game time)
            timeOfDay += Time.deltaTime;
            timeOfDay %= 24; //Modulus to ensure always between 0-24
            updateLight(timeOfDay / 24f);
        }
        else
        {
            updateLight(timeOfDay / 24f);
        }
    }

    private void updateLight(float timePercent)
    {
        RenderSettings.ambientLight = AmbientColor.Evaluate(timePercent);
        RenderSettings.fogColor = FogColor.Evaluate(timePercent);

        if(directionalLight != null)
        {
            directionalLight.color = DirectionalColor.Evaluate(timePercent);
            directionalLight.transform.localRotation = Quaternion.Euler(new Vector3((timePercent * 360f) - 90f, 170f, 0));
        }
    }
}
