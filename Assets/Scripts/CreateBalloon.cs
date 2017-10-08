using UnityEngine;

public class CreateBalloon : MonoBehaviour
{

    // Called by GazeGestureManager when the user performs a Select gesture
    void OnSelect()
    {
        if (GameObject.Find("balloon(Clone)") == null)
        {
            Instantiate(Resources.Load("balloon"));
            GameObject.Find("balloon(Clone)").transform.position += new Vector3(0, 0, 0.6f);
        }

        else
        {
            GameObject.Find("balloon(Clone)").SetActive(false);
        }
        
    }

    // Called by SpeechManager when the user says the "Reset object" command
    void OnReset()
    {
        GameObject.Find("balloon(Clone)").SetActive(false);
        DestroyObject(GameObject.Find("balloon(Clone)"));
    }

    // Called by SpeechManager when the user says the "Create object" command
    void OnBalloon()
    {
        // Just do the same logic as a Select gesture.
        OnSelect();
    }
}