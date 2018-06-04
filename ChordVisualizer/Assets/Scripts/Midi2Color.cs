using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MidiJack;

public class Midi2Color : MonoBehaviour {

    //Fetch the Renderer from the GameObject
    Renderer rend;
    public int noteNumber;

    // Use this for initialization
    void Start () {
        rend = GetComponent<Renderer>();

        //Set the main Color of the Material to green
        rend.material.shader = Shader.Find("_Color");
        rend.material.SetColor("_Color", Color.green);

        //Find the Specular shader and change its Color to red
        rend.material.shader = Shader.Find("Specular");
        rend.material.SetColor("_SpecColor", Color.red);
    }
	
	// Update is called once per frame
	void Update () {
        //rend.material.SetColor("_Color", new Color(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f)));


        //transform.localScale = Vector3.one * (0.1f + MidiMaster.GetKey(noteNumber));

        if (MidiMaster.GetKeyDown(108))
        {
            rend.material.SetColor("_Color", Color.red);
        }
        if (MidiMaster.GetKeyDown(107))
        {
            rend.material.SetColor("_Color", Color.blue);
        }
        if (MidiMaster.GetKeyDown(106))
        {
            rend.material.SetColor("_Color", Color.green);
        }

    }
}
