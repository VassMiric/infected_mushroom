using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class WorldState1 : MonoBehaviour
{
    public GameObject cam;
    public WorldToggleState toggle;
    // Start is called before the first frame update
    void Start()
    {
        toggle = cam.GetComponent<WorldToggleState>();
    }

    // Update is called once per frame
    void Update()
    {
        
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
