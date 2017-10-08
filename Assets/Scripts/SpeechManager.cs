using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Windows.Speech;

public class SpeechManager : MonoBehaviour
{
    KeywordRecognizer keywordRecognizer = null;
    Dictionary<string, System.Action> keywords = new Dictionary<string, System.Action>();

    // Use this for initialization
    void Start()
    {
        keywords.Add("Show Info", () =>
        {
            var focusObject = GazeGestureManager.Instance.FocusedObject;
            if (focusObject != null)
            {
                // Call the OnMove method on just the focused object.
                focusObject.SendMessage("OnAnnotate", SendMessageOptions.DontRequireReceiver);
            }
        });

        keywords.Add("Annotate", () =>
        {
            var focusObject = GazeGestureManager.Instance.FocusedObject;
            if (focusObject != null)
            {
                // Call the OnMove method on just the focused object.
                focusObject.SendMessage("OnAnnotate", SendMessageOptions.DontRequireReceiver);
            }
        });

        keywords.Add("Move Object", () =>
        {
            var focusObject = GazeGestureManager.Instance.FocusedObject;
            if (focusObject != null)
            {
                // Call the OnMove method on just the focused object.
                focusObject.SendMessage("OnMove", SendMessageOptions.DontRequireReceiver);
            }
        });

        keywords.Add("Place Object", () =>
        {
            var focusObject = GazeGestureManager.Instance.FocusedObject;
            if (focusObject != null)
            {
                // Call the OnMove method on just the focused object.
                focusObject.SendMessage("OnMove", SendMessageOptions.DontRequireReceiver);
            }
        });

        keywords.Add("Delete Object", () =>
        {
            var focusObject = GazeGestureManager.Instance.FocusedObject;
            if (focusObject != null)
            {
                // Call the OnDelete method on just the focused object.
                focusObject.SendMessage("OnDelete", SendMessageOptions.DontRequireReceiver);
            }
        });
        
        keywords.Add("Create Lithium", () =>
        {
            // Should call OnCreate on the Lithum component in the menu
            GameObject.Find("Menu/Lithium Icon").SendMessage("OnCreate");
        });

        keywords.Add("Create Aluminum", () =>
        {
            // Should call OnCreate on the Aluminum component in the menu
            GameObject.Find("Menu/Aluminum Icon").SendMessage("OnCreate");
        });

        keywords.Add("Create Potassium", () =>
        {
            // Should call OnCreate on the Potassium component in the menu
            GameObject.Find("Menu/Potassium Icon").SendMessage("OnCreate");
        });

        keywords.Add("Create Carbon", () =>
        {
            // Should call OnCreate on the Carbon component in the menu
            GameObject.Find("Menu/Carbon Icon").SendMessage("OnCreate");
        });

        keywords.Add("Create Neon", () =>
        {
            // Should call OnCreate on the Carbon component in the menu
            GameObject.Find("Menu/Neon Icon").SendMessage("OnCreate");
        });

        keywords.Add("Create Helium", () =>
        {
            // Should call OnCreate on the Helium component in the menu
            GameObject.Find("Menu/Helium Icon").SendMessage("OnCreate");
        });

        keywords.Add("Show Lines", () =>
        {
            // Should call OnCreate on the Aluminum component in the menu
            GameObject.Find("Menu/Line Manager").SendMessage("OnCreate");
        });

        keywords.Add("Hide Lines", () =>
        {
            // Should call OnCreate on the Aluminum component in the menu
            GameObject.Find("Menu/Line Manager").SendMessage("OnCreate");
        });

        keywords.Add("Start Quiz", () =>
        {
            // Should call OnCreate on the Aluminum component in the menu
            GameObject.Find("Menu/Quiz Manager").SendMessage("OnSelect");
        });

        keywords.Add("Stop Quiz", () =>
        {
            // Should call OnCreate on the Aluminum component in the menu
            GameObject.Find("Menu/Quiz Manager").SendMessage("OnSelect");
        });

        // Tell the KeywordRecognizer about our keywords.
        keywordRecognizer = new KeywordRecognizer(keywords.Keys.ToArray());

        // Register a callback for the KeywordRecognizer and start recognizing!
        keywordRecognizer.OnPhraseRecognized += KeywordRecognizer_OnPhraseRecognized;
        keywordRecognizer.Start();
    }

    private void KeywordRecognizer_OnPhraseRecognized(PhraseRecognizedEventArgs args)
    {
        System.Action keywordAction;
        if (keywords.TryGetValue(args.text, out keywordAction))
        {
            keywordAction.Invoke();
        }
    }
}