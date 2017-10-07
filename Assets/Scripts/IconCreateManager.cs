using UnityEngine;

public class IconCreateManager : MonoBehaviour
{
    Vector3 originalPosition;
    string objName;
    GameObject selectedObject;

    // Use this for initialization
    void Start()
    {
        // Grab the original local position of the sphere when the app starts.
        originalPosition = this.transform.localPosition;
    }

    // Called by GazeGestureManager when the user performs a Select gesture
    void OnSelect()
    {
        objName = gameObject.transform.name.Split()[0];
        selectedObject = GameObject.Find(objName + " Object(Clone)");
        if (selectedObject == null)
        {
            Instantiate(Resources.Load(objName + " Object"));
            selectedObject = GameObject.Find(objName + " Object(Clone)");
            selectedObject.AddComponent<TapToPlace>();
            selectedObject.AddComponent<BoxCollider>();
            selectedObject.transform.position = Camera.main.transform.forward;
        }

        else
        {
            selectedObject.SetActive(false);
        }

    }

    // Called by SpeechManager when the user says the "Create object" command
    void OnCreate()
    {
        // Just do the same logic as a Select gesture.
        OnSelect();
    }
}