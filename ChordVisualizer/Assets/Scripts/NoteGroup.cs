using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteGroup : MonoBehaviour {

    public GameObject prefab;
    public int NumberOfNotes = 128;

    void Start()
    {
        GameObject parentObject = GameObject.Find("MidiIdentifier");

        for (var i = 0; i < NumberOfNotes; i++)
        {
            var go = Instantiate<GameObject>(prefab);
            //go.transform.position = new Vector3(i % 12, i / 12, 0);
            go.GetComponent<NoteIndicator>().noteNumber = i;
            go.transform.parent = parentObject.transform;
        }
    }
}
