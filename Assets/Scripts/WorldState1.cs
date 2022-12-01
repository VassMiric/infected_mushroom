using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class WorldState1 : MonoBehaviour
{
    public bool riverAppear;
    public GameObject cam;
    public WorldToggleState toggle;
    // Start is called before the first frame update
    void Start()
    {
        riverAppear = false;
        toggle = cam.GetComponent<WorldToggleState>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void riverTrigger()
    {
        Debug.Log("The River has been triggered");
        if(riverAppear)
        {
            riverAppear = false;
        }
        else
        {
            riverAppear = true;
        }
    }

    public void triggerToggle()
    {
        toggle.triggerPsychadelic();
    }

    public void sceneReset()
    {
        Debug.Log("Spawning Scene " + SceneManager.GetActiveScene());
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
