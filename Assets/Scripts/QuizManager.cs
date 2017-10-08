using UnityEngine;

public class QuizManager : MonoBehaviour
{
    private bool quizOn = false;

    // Called by GazeGestureManager when the user performs a Select gesture
    void OnSelect() //Need to disable all children mesh renderers, and toggle questionmark
    {
        //GameObject[] objects = GameObject.Find("Object Collection").GetComponentsInChildren<GameObject>();
        //GameObject[] qMarks = GameObject.Find("Quiz Collection").GetComponentsInChildren<GameObject>();

        Renderer[] renderers = GameObject.Find("Object Collection").GetComponentsInChildren<Renderer>();

        if (!quizOn)
        {
            foreach (Renderer child in renderers)
            {
                child.enabled = false;
            }

            for (int i = 0; i < GameObject.Find("Object Collection").transform.childCount; i++)
            {
                GameObject.Find("Object Collection").transform.GetChild(i).GetChild(0).GetComponent<Renderer>().enabled = true;
            }
            quizOn = true;
        }

        else
        {
            foreach (Renderer child in renderers)
            {
                child.enabled = true;
            }

            for (int i = 0; i < GameObject.Find("Object Collection").transform.childCount; i++)
            {
                GameObject.Find("Object Collection").transform.GetChild(i).GetChild(0).GetComponent<Renderer>().enabled = false;
            }
            quizOn = false;
        }

    }

}