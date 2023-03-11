using UnityEngine;


public class ButtonBehavior : MonoBehaviour
{
    
    public GameObject obj;
    private bool active;
    public Material material1;
    public Material material2;
    public ParticleSystem fire;
    public Light lightObject;


    void Start(){
        active = false;
    }

    void OnMouseDown(){
        Debug.Log("Mouse on tree");
        changeMaterial();
        fire.Play();
    }


    void changeMaterial()
    {
        if(!active)
        {
            obj.GetComponent<MeshRenderer>().material = material2;
            //lightObject.color = Color.blue;
            lightObject.intensity = 0.5F;
        } 
        else
        {
            obj.GetComponent<MeshRenderer>().material = material1;
            //lightObject.color = new Color(255,244,214,255);
            lightObject.intensity = 1;
        } 
        active = !active;
    }

    

}
