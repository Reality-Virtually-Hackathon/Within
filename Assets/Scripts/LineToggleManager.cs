using UnityEngine;

public class LineToggleManager : MonoBehaviour
{
    private bool lineOn = false;

    // Called by GazeGestureManager when the user performs a Select gesture
    private void OnSelect()
    {

        if (!lineOn)
        {
            GameObject parent = GameObject.Find("Object Collection");
            if (GameObject.Find("Lines") == false)
            {
                GameObject line2 = new GameObject("Lines", typeof(LineRenderer));
                LineRenderer line1 = line2.GetComponent<LineRenderer>();

                line1.positionCount = parent.transform.childCount;
                for (int i = 0; i < parent.transform.childCount; i++)
                { 
                    line1.SetPosition(i, parent.transform.GetChild(i).position);
                }
                
                line1.startWidth = 0.04f;
                line1.endWidth = 0.04f;

                line1.materials[0] = Resources.Load("Scripts/Materials/anisotropic1.mat", typeof(Material)) as Material;
                line1.startColor = Color.blue;
            }

            else
            {
                recalculateLines();
                GameObject.Find("Lines").GetComponent<LineRenderer>().enabled = true;
            }

            lineOn = true;
        }

        else
        {
            GameObject.Find("Lines").GetComponent<LineRenderer>().enabled = false;
            lineOn = false;
        }      
                
    }

    // Called by SpeechManager when the user says the "Create object" command
    void OnCreate()
    {
        // Just do the same logic as a Select gesture.
        OnSelect();
    }

    public static void recalculateLines()
    {
        GameObject.Find("Lines").GetComponent<LineRenderer>().enabled = false;
        GameObject parent = GameObject.Find("Object Collection");
        LineRenderer line1 = GameObject.Find("Lines").GetComponent<LineRenderer>();

        line1.positionCount = parent.transform.childCount;
        for (int i = 0; i < parent.transform.childCount; i++)
        {
            line1.SetPosition(i, parent.transform.GetChild(i).position);
        }

        line1.startWidth = 0.04f;
        line1.endWidth = 0.04f;

        line1.materials[0] = Resources.Load("Scripts/Materials/anisotropic1.mat", typeof(Material)) as Material;
        line1.startColor = Color.blue;
    }
}