using UnityEngine;

public class LineToggleManager : MonoBehaviour
{
    Vector3 originalPosition;
    string objName;
    GameObject selectedObject;
    Bounds _bounds;

    // Called by GazeGestureManager when the user performs a Select gesture
    void OnSelect()
    {
        GameObject line2 = new GameObject("line2", typeof(LineRenderer));
        LineRenderer line1 = line2.GetComponent<LineRenderer>();
        Vector3[] points = new[] { GameObject.Find("Aluminum Object(Clone)").transform.position, GameObject.Find("Lithium Object(Clone)").transform.position, GameObject.Find("Potassium Object(Clone)").transform.position};
        line1.positionCount = 3;
        line1.SetPositions(points);
        line1.startWidth = 0.04f;
        line1.endWidth = 0.04f;
        line1.SetWidth(0.04f, 0.04f);

        line1.materials[0] = Resources.Load("Scripts/Materials/anisotropic1.mat", typeof(Material)) as Material;
        line1.startColor = Color.blue;
        
        
        /*
        Gizmos.color = Color.blue;
        Gizmos.DrawLine(GameObject.Find("Aluminum Object(Clone)").transform.position, GameObject.Find("Lithium Object(Clone)").transform.position);

        Gizmos.color = Color.blue;
        Gizmos.DrawLine(GameObject.Find("Lithium Object(Clone)").transform.position, GameObject.Find("Potassium Object(Clone)").transform.position);
        */
    }

    // Called by SpeechManager when the user says the "Create object" command
    void OnCreate()
    {
        // Just do the same logic as a Select gesture.
        OnSelect();
    }
}