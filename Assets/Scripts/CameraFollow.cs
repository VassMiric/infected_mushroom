using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;
    public float smoothing = 5f;
    public Camera cam;
    Vector3 offset;
    void Start()
    {
        offset = transform.position - target.position;
    }

    // Update is called once per frame
    private void Update() 
    {
        if(Input.mouseScrollDelta.y > 0)
            cam.orthographicSize -= .5f;
        if(Input.mouseScrollDelta.y < 0)
            cam.orthographicSize += .5f;
    }
    void LateUpdate()
    {
        Vector3 targetCamPos = target.position + offset;
        transform.position = Vector3.Lerp(transform.position, targetCamPos, smoothing * Time.deltaTime);
    }
}
