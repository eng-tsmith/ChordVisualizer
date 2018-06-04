using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MidiJack;

public class Midi2Color : MonoBehaviour {

    //Fetch the Renderer from the GameObject
    Renderer rend;

    private GameObject meshobject;
    private BuildMesh meshscript;

    public Dictionary<int, bool> pressedKeys;

    private GameObject Group; 
    private NoteGroup _notegroup;

    // Use this for initialization
    void Start () {
        rend = GetComponent<Renderer>();

        //Set the main Color of the Material to green
        rend.material.shader = Shader.Find("_Color");
        rend.material.SetColor("_Color", new Color(0.5f, 0.5f, 0.5f));

        //Find the Specular shader and change its Color to red
        rend.material.shader = Shader.Find("Specular");
        rend.material.SetColor("_SpecColor", Color.red);

        meshobject = GameObject.Find("Cube");
        meshscript = meshobject.GetComponent<BuildMesh>();

        // Create dictionary to store notes
        pressedKeys = new Dictionary<int, bool>();
        Group = GameObject.Find("Group");
        _notegroup = Group.GetComponent<NoteGroup>();

        for (int i = 0; i< _notegroup.NumberOfNotes; i++)
        {
            pressedKeys.Add(i, false);
        }
    }
	
	// Update is called once per frame
	void Update () {

        foreach (var pair in pressedKeys)
        {
            if(pair.Value)
            {
                if (pair.Key%12 == 0)
                {
                    rend.material.SetColor("_Color", new Color(0.1f, 0.1f, 0.1f));
                }
                if (pair.Key % 12 == 1)
                {
                    rend.material.SetColor("_Color", new Color(0.2f, 0.2f, 0.2f));
                }
                if (pair.Key % 12 == 2)
                {
                    rend.material.SetColor("_Color", new Color(0.3f, 0.3f, 0.3f));
                }
                if (pair.Key % 12 == 3)
                {
                    rend.material.SetColor("_Color", new Color(0.4f, 0.4f, 0.4f));
                }
                if (pair.Key % 12 == 4)
                {
                    rend.material.SetColor("_Color", new Color(0.5f, 0.5f, 0.5f));
                }
                if (pair.Key % 12 == 5)
                {
                    rend.material.SetColor("_Color", new Color(0.6f, 0.6f, 0.6f));
                }
                if (pair.Key % 12 == 6)
                {
                    rend.material.SetColor("_Color", new Color(0.7f, 0.7f, 0.7f));
                }
                if (pair.Key % 12 == 7)
                {
                    rend.material.SetColor("_Color", new Color(0.8f, 0.8f, 0.8f));
                }
                if (pair.Key % 12 == 8)
                {
                    rend.material.SetColor("_Color", new Color(0.9f, 0.9f, 0.9f));
                }
                if (pair.Key % 12 == 9)
                {
                    rend.material.SetColor("_Color", new Color(1f, 1f, 1f));
                }
                if (pair.Key % 12 == 10)
                {
                    rend.material.SetColor("_Color", new Color(0f, 0f, 0f));
                }
                if (pair.Key % 12 == 11)
                {
                    rend.material.SetColor("_Color", new Color(1f, 0f, 0f));
                }
            }
        }

        if (meshscript.shapeN > 3)
        {
            meshscript.shapeN = 0;
        }

        /*if (MidiMaster.GetKeyDown(108))
        {
            rend.material.SetColor("_Color", new Color(0.5f, 0.5f, 0.5f));
            meshscript.shapeN++;           
        }
        if (MidiMaster.GetKeyDown(107))
        {
            rend.material.SetColor("_Color", new Color(0.25f, 0.5f, 0.555f));
            meshscript.shapeN++;
        }
        if (MidiMaster.GetKeyDown(106))
        {
            rend.material.SetColor("_Color", new Color(0.2f, 0.2f, 0.2f));
            meshscript.shapeN++;
        }*/
    }
}
