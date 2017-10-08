using UnityEngine;

public class IconCreateManager : MonoBehaviour
{

    string objName;
    GameObject selectedObject;
    Bounds _bounds;

    // Called by GazeGestureManager when the user performs a Select gesture
    void OnSelect()
    {
        objName = gameObject.transform.name.Split()[0];
        selectedObject = GameObject.Find(objName + " Object(Clone)");
        if (selectedObject == null)
        {
            selectedObject = (GameObject) Instantiate(Resources.Load(objName + " Object"));
            // selectedObject = GameObject.Find(objName + " Object(Clone)");
            // selectedObject.AddComponent<TapToPlace>();
            selectedObject.AddComponent<ObjectToolsManager>();
            BoxCollider collider = selectedObject.AddComponent<BoxCollider>();
            calculateBounds();
            collider.center = _bounds.center;
            collider.size = _bounds.size;

            // Do a raycast into the world that will only hit the Spatial Mapping mesh.
            var headPosition = Camera.main.transform.position;
            var gazeDirection = Camera.main.transform.forward;

            selectedObject.transform.position = headPosition + gazeDirection/2;

            // Rotate this object's parent object to face the user.
            Quaternion toQuat = Camera.main.transform.localRotation;
            toQuat.x = 0;
            toQuat.z = 0;
            selectedObject.transform.rotation = toQuat;
            
            //Debug toggling of objects if necessary
            selectedObject.transform.parent = GameObject.Find("Object Collection").transform;

            var qMark = (GameObject) Instantiate(Resources.Load("QuestionMark"), selectedObject.transform);
            qMark.transform.SetAsFirstSibling();
            qMark.GetComponent<Renderer>().enabled = false;

            selectedObject.SendMessage("OnSelect");

        }

        else
        {
            return;
            Debug.Log("Object found!!");
            if (selectedObject.activeSelf)
            {                 
                selectedObject.SetActive(false);
            }
            else
            {
                selectedObject.SetActive(true);
            }
                
        }

    }

    // Called by SpeechManager when the user says the "Create object" command
    void OnCreate()
    {
        // Just do the same logic as a Select gesture.
        Debug.Log("CALLED CREATE BY VOICE");
        OnSelect();
    }

    void OnAnnotate()
    {
        // When "annotate object" is recognized from voice dictation
        Debug.Log("ANNOTATE HERE WORKS");
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