using UnityEngine;

public class LineToggleManager : MonoBehaviour
{
    private bool lineOn = false;

    // Called by GazeGestureManager when the user performs a Select gesture
    void OnSelect()
    {
        if (!lineOn)
        {
            if (GameObject.Find("Lines") == false)
            {
                GameObject line2 = new GameObject("Lines", typeof(LineRenderer));
                LineRenderer line1 = line2.GetComponent<LineRenderer>();
                Vector3[] points = new[] { GameObject.Find("Aluminum Object(Clone)").transform.position, GameObject.Find("Lithium Object(Clone)").transform.position, GameObject.Find("Potassium Object(Clone)").transform.position };
                line1.positionCount = 3;
                line1.SetPositions(points);
                line1.startWidth = 0.04f;
                line1.endWidth = 0.04f;

                line1.materials[0] = Resources.Load("Scripts/Materials/anisotropic1.mat", typeof(Material)) as Material;
                line1.startColor = Color.blue;
            }

            else
            {
                GameObject.Find("Lines").GetComponent<LineRenderer>().enabled = true;
            }

            lineOn = true;
        }

        else
        {
            GameObject.Find("Lines").GetComponent<LineRenderer>().enabled = false;
        }      
                
    }

    // Called by SpeechManager when the user says the "Create object" command
    void OnCreate()
    {
        // Just do the same logic as a Select gesture.
        OnSelect();
    }
}