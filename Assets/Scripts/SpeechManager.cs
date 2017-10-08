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
        keywords.Add("Reset Object", () =>
        {
            var focusObject = GazeGestureManager.Instance.FocusedObject;
            if (focusObject != null)
            {
                // Call the OnMove method on just the focused object.
                focusObject.SendMessage("OnReset", SendMessageOptions.DontRequireReceiver);
            }
        });

        keywords.Add("Move Object", () =>
        {
            var focusObject = GazeGestureManager.Instance.FocusedObject;
            if (focusObject != null)
            {
                // Call the OnMove method on just the focused object.
                focusObject.SendMessage("OnSelect", SendMessageOptions.DontRequireReceiver);
            }
        });

        keywords.Add("Testing", () =>
        {
            var focusObject = GazeGestureManager.Instance.FocusedObject;
            if (focusObject != null)
            {
                // Call the OnAnnotate method on just the focused object.
                focusObject.SendMessage("OnAnnotate", SendMessageOptions.DontRequireReceiver);
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
            // Should call OnCreate on the Aluminum component in the menu
            GameObject.Find("Menu/Potassium Icon").SendMessage("OnCreate");
        });

        keywords.Add("Show lines", () =>
        {
            // Should call OnCreate on the Aluminum component in the menu
            GameObject.Find("Menu/LineManager").SendMessage("OnCreate");
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