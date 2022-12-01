using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;


[CustomEditor(typeof(VisionCone))]
public class VisionConeEditor : Editor
{
    private void OnSceneGUI()
    {
        VisionCone cone = (VisionCone)target;
        Handles.color = Color.white;
        Handles.DrawWireArc(cone.transform.position, Vector3.up, Vector3.forward, 360, cone.Radius);

        Vector3 viewAngle1 = DirectionFromAngle(cone.transform.eulerAngles.y, -cone.Angle / 2);
        Vector3 viewAngle2 = DirectionFromAngle(cone.transform.eulerAngles.y, cone.Angle / 2);

        Handles.color = Color.yellow;
        Handles.DrawLine(cone.transform.position, cone.transform.position + viewAngle1 * cone.Radius);
        Handles.DrawLine(cone.transform.position, cone.transform.position + viewAngle2 * cone.Radius);

        if (cone.PlayerVisible)
        {
            Handles.color = Color.green;
            Handles.DrawLine(cone.transform.position, cone.Player.transform.position);
        }
    }

    private Vector3 DirectionFromAngle(float y, float angleInDegrees)
    {
        angleInDegrees += y;

        return new Vector3(Mathf.Sin(angleInDegrees * Mathf.Deg2Rad), 0, Mathf.Cos(angleInDegrees * Mathf.Deg2Rad));
    }
}
