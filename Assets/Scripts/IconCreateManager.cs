using UnityEngine;

public class IconCreateManager : MonoBehaviour
{
    Vector3 originalPosition;
    string objName;
    GameObject selectedObject;
    Bounds _bounds;

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
            BoxCollider collider = selectedObject.AddComponent<BoxCollider>();
            collider.center = _bounds.center;
            collider.size = new Vector3(0.1f,0.1f,0.1f);
            Debug.DrawRay(Camera.main.transform.position, Camera.main.transform.forward, Color.red);
            selectedObject.transform.position = Camera.main.transform.forward/2;
            selectedObject.transform.parent = GameObject.Find("Menu").transform;
        }

        else
        {
            Destroy(selectedObject);
            selectedObject.SetActive(false);
        }

    }

    // Called by SpeechManager when the user says the "Create object" command
    void OnCreate()
    {
        // Just do the same logic as a Select gesture.
        OnSelect();
    }

    void OnAnnotate()
    {
        // Just do the same logic as a Select gesture.
        Debug.Log("IT WORKS");
    }

    void calculateBounds()
    {
        _bounds = new Bounds(selectedObject.transform.position, Vector3.zero);
        Renderer[] renderers = selectedObject.GetComponentsInChildren<Renderer>();
        foreach (Renderer child in renderers)
        {
            _bounds.Encapsulate(child.bounds);
        }
    }
}