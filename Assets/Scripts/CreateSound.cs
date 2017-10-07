using UnityEngine;

public class CreateSound : MonoBehaviour
{
    Vector3 originalPosition;

    // Use this for initialization
    void Start()
    {
        // Grab the original local position of the sphere when the app starts.
        originalPosition = this.transform.localPosition;
    }

    // Called by GazeGestureManager when the user performs a Select gesture
    void OnSelect()
    {
        if(GameObject.Find("Sound(Clone)") == null)
        {
            Instantiate(Resources.Load("Sound"));
            GameObject.Find("Sound(Clone)").transform.position += new Vector3(0, 0, 2);
        }

        else
        {
            GameObject.Find("Sound(Clone)").SetActive(false);
        }
        
    }

    // Called by SpeechManager when the user says the "Reset world" command
    void OnReset()
    {
        GameObject.Find("Sound(Clone)").SetActive(false);
        DestroyObject(GameObject.Find("Sound(Clone)"));
    }

    // Called by SpeechManager when the user says the "Drop sphere" command
    void OnSound()
    {
        // Just do the same logic as a Select gesture.
        OnSelect();
    }
}