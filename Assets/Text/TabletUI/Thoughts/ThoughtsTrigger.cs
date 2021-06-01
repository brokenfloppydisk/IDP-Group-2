using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThoughtsTrigger : MonoBehaviour
{
    private ThoughtsManager thoughtsManager;
    [SerializeField]
    private bool hover = true;
    [SerializeField]
    [TextArea(2,3)]
    public string sentence;
    private void Start() {
        thoughtsManager = ThoughtsManager.Instance;
    }
    public void Trigger() {
        thoughtsManager.DisplayThoughts(sentence);
    }
    public void Trigger(string sentence) {
        thoughtsManager.DisplayThoughts(sentence);
    }

    private void OnMouseEnter() {
        if (hover) {
            Trigger();
        }
    }
}
