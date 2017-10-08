using UnityEngine;

public class QuizManager : MonoBehaviour
{
    private bool quizOn = false;

    // Called by GazeGestureManager when the user performs a Select gesture
    void OnSelect()
    {
        GameObject[] objects = GameObject.Find("Object Collection").GetComponentsInChildren<GameObject>();
        GameObject[] qMarks = GameObject.Find("Quiz Collection").GetComponentsInChildren<GameObject>();

        if (!quizOn)
        {  
            for (int i = 0; i < objects.Length; i++)
            {
                objects[0].SetActive(false);
                qMarks[0].SetActive(true);
            }
        }

        else
        {
            for (int i = 0; i < objects.Length; i++)
            {
                qMarks[0].SetActive(false);
                objects[0].SetActive(true);
            }
        }

    }

}