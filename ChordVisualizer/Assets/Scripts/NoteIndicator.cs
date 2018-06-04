using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MidiJack;

public class NoteIndicator : MonoBehaviour {

    public int noteNumber;
    public string note;

    private GameObject Cube;
    private Midi2Color _midi2color;
    
    private void Start()
    {
        Cube = GameObject.Find("Cube");
        _midi2color = Cube.GetComponent<Midi2Color>();

        switch (noteNumber % 12)
        {
            case 0:
                note = "c";
                break;
            case 1:
                note = "db";
                break;
            case 2:
                note = "d";
                break;
            case 3:
                note = "eb";
                break;
            case 4:
                note = "e";
                break;
            case 5:
                note = "f";
                break;
            case 6:
                note = "gb";
                break;
            case 7:
                note = "g";
                break;
            case 8:
                note = "ab";
                break;
            case 9:
                note = "a";
                break;
            case 10:
                note = "bb";
                break;
            case 11:
                note = "b";
                break;
            default:
                note = "-";
                break;
        }
    }

    void Update()
    {
        //transform.localScale = Vector3.one * (0.1f + MidiMaster.GetKey(noteNumber));


        if (MidiMaster.GetKeyDown(noteNumber))
        {
            //Debug.Log(noteNumber + "down");
            _midi2color.pressedKeys[noteNumber] = true;
        }
        if (MidiMaster.GetKeyUp(noteNumber))
        {
            //Debug.Log(noteNumber + "up");
            _midi2color.pressedKeys[noteNumber] = false;
        }
        //GetComponent<Renderer>().material.color = color;
    }
}
