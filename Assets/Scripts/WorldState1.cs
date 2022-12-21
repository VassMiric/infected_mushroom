using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class WorldState1 : MonoBehaviour
{
    public GameObject cam;
    public WorldToggleState toggle;
    GameObject[] enemies;
    public bool win;
    // Start is called before the first frame update
    void Start()
    {
        toggle = cam.GetComponent<WorldToggleState>();
        enemies = GameObject.FindGameObjectsWithTag("Enemy");
    }

    // Update is called once per frame
    void Update()
    {
        if(enemies.Length == 0)
        {
            win = true;
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
