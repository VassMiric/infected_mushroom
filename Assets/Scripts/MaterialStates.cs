using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class MaterialStates : MonoBehaviour
{
    public Material mat1;
    public Material mat2;
    public Renderer render;

    public WorldToggleState toggle;

    public Camera cam;
    

    // Start is called before the first frame update
    void Start()
    {
        toggle = cam.GetComponent<WorldToggleState>();
    }

    // Update is called once per frame
    void Update()
    {
        if(toggle.getPsychState())
        {
            render.material = mat2;
        }
        else 
        {
            render.material = mat1;
        }
    }
}
