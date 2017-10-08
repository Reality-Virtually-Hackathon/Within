﻿using UnityEngine;

public class ObjectToolsManager : MonoBehaviour
{
    bool placing = false;

    // Called by GazeGestureManager when the user performs a Select gesture
    void OnSelect()
    {
        Debug.Log(placing);

        // On each Select gesture, toggle whether the user is in placing mode.
        placing = !placing;

        // If the user is in placing mode, display the spatial mapping mesh.
        if (placing)
        {
            SpatialMapping.Instance.DrawVisualMeshes = false;
        }
        // If the user is not in placing mode, hide the spatial mapping mesh.
        else
        {
            SpatialMapping.Instance.DrawVisualMeshes = false;
        }

    }

    void OnMove()
    {
        Debug.Log("Moving!");
        OnSelect();
    }

    void OnAnnotate()
    {
        Debug.Log("Annotation!!");

    }

    // Update is called once per frame
    void Update()
    {
        // If the user is in placing mode,
        // update the placement to match the user's gaze.

        if (placing)
        {
            // Do a raycast into the world that will only hit the Spatial Mapping mesh.
            var headPosition = Camera.main.transform.position;
            var gazeDirection = Camera.main.transform.forward;

            RaycastHit hitInfo;
            if (Physics.Raycast(headPosition, gazeDirection, out hitInfo,
                20f, SpatialMapping.PhysicsRaycastMask))
            {
                // Move this object's parent object to
                // where the raycast hit the Spatial Mapping mesh.
                gameObject.transform.position = hitInfo.point;

                // Rotate this object's parent object to face the user.
                Quaternion toQuat = Camera.main.transform.localRotation;
                toQuat.x = 0;
                toQuat.z = 0;
                gameObject.transform.rotation = toQuat;
            }
        }
    }

    // Called by SpeechManager when the user says the "Delete object" command
    void OnDelete()
    {
        gameObject.SetActive(false);
        Destroy(gameObject);
    }

    // Called by SpeechManager when the user says the "Reset object" command
    void OnReset()
    {
        OnSelect();
    }

}