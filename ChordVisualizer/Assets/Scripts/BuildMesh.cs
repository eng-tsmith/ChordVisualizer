using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildMesh : MonoBehaviour {

    // start as Hexaeder
    public Vector3 vertltf = new Vector3(-1, 1, 1);
    public Vector3 vertrtf = new Vector3(1, 1, 1);
    public Vector3 vertlbf = new Vector3(-1, -1, 1);
    public Vector3 vertrbf = new Vector3(1, -1, 1);
    public Vector3 vertrtb = new Vector3(1, 1, -1);
    public Vector3 vertltb = new Vector3(-1, 1, -1);
    public Vector3 vertrbb = new Vector3(1, -1, -1);
    public Vector3 vertlbb = new Vector3(-1, -1, -1);

    private float defaultT = 1f;
    private float timerT = 1f;

    public int shapeN = 0;

    // Use this for initialization
    void Start () {
        MeshFilter mf = GetComponent<MeshFilter>();
        Mesh mesh = mf.mesh;

        // Vertices 
        Vector3[] vertices = new Vector3[]
        {
            // front
            vertltf, //left  top front, 0
            vertrtf, //right top front, 1
            vertlbf, //left  bot front, 2
            vertrbf, //right bot front, 3

            // back
            vertrtb, //right top back, 4
            vertltb, //left  top back, 5
            vertrbb, //right bot back, 6
            vertlbb, //left  bot back, 7

            // left
            vertltb, //left  top back,  8
            vertltf, //left  top front, 9
            vertlbb, //left  bot back,  10
            vertlbf, //left  bot front, 11

            // right
            vertrtf, //right top front, 12
            vertrtb, //right top back,  13
            vertrbf, //right bot front, 14
            vertrbb, //right bot back,  15

            // top
            vertltb, //left  top back,  16
            vertrtb, //right top back,  17
            vertltf, //left  top front, 18
            vertrtf, //right top front, 19

            // bot
            vertlbf, //left  bot front, 20
            vertrbf, //right bot front, 21
            vertlbb, //left  bot back,  22
            vertrbb  //right bot back,  23
        };

        // Triangles
        int[] trangles = new int[]
        {
            // front face
            0,2,3, // first 
            3,1,0, // second

            // back face
            4,6,7, // first 
            7,5,4, // second

            // left face
            8,10,11, // first 
            11,9,8, // second

            // right face
            12,14,15, // first 
            15,13,12, // second

            // top face
            16,18,19, // first 
            19,17,16, // second

            // bot face
            20,22,23, // first 
            23,21,20 // second
        };

        // UVs
        Vector2[] uvs = new Vector2[]
        {
            //front face
            new Vector2(0,  1),//0,0 bottom left
            new Vector2(0,  0), //1,1 top right
            new Vector2(1,  1), //1,1 top right
            new Vector2(1,  0), //1,1 top right

            //back face
            new Vector2(0,  1), //0,0 bottom left
            new Vector2(0,  0), //1,1 top right
            new Vector2(1,  1), //1,1 top right
            new Vector2(1,  0), //1,1 top right

            //left face
            new Vector2(0,  1),//0,0 bottom left
            new Vector2(0,  0), //1,1 top right
            new Vector2(1,  1), //1,1 top right
            new Vector2(1,  0), //1,1 top right

            //right face
            new Vector2(0,  1),//0,0 bottom left
            new Vector2(0,  0), //1,1 top right
            new Vector2(1,  1), //1,1 top right
            new Vector2(1,  0), //1,1 top right

            //top face
            new Vector2(0,  1),//0,0 bottom left
            new Vector2(0,  0), //1,1 top right
            new Vector2(1,  1), //1,1 top right
            new Vector2(1,  0), //1,1 top right

            //bot face
            new Vector2(0,  1),//0,0 bottom left
            new Vector2(0,  0), //1,1 top right
            new Vector2(1,  1), //1,1 top right
            new Vector2(1,  0) //1,1 top right
        };

        mesh.Clear();
        mesh.vertices = vertices;
        mesh.triangles = trangles;
        mesh.uv = uvs;
        //mesh.Optimize();
        mesh.RecalculateNormals();
        
	}
	
	// Update is called once per frame
	void Update () {

        if (timerT > 0f) {
            timerT -= Time.deltaTime;
        }
        else {
            timerT = defaultT;
        }

        //cube
        if (shapeN == 0)
        {
            vertltf = Vector3.Lerp(vertltf, new Vector3(-1, 1, 1), Time.deltaTime);
            vertrtf = Vector3.Lerp(vertrtf, new Vector3(1, 1, 1), Time.deltaTime);
            vertltb = Vector3.Lerp(vertltb, new Vector3(-1, 1, -1), Time.deltaTime);
            vertrtb = Vector3.Lerp(vertrtb, new Vector3(1, 1, -1), Time.deltaTime);

            vertlbf = Vector3.Lerp(vertlbf, new Vector3(-1, -1, 1), Time.deltaTime);
            vertrbf = Vector3.Lerp(vertrbf, new Vector3(1, -1, 1), Time.deltaTime);
            vertlbb = Vector3.Lerp(vertlbb, new Vector3(-1, -1, -1), Time.deltaTime);
            vertrbb = Vector3.Lerp(vertrbb, new Vector3(1, -1, -1), Time.deltaTime);
        }
        // tetra
        if (shapeN == 1)
        {
            vertltf = Vector3.Lerp(vertltf, new Vector3(0, 1, 0), Time.deltaTime);
            vertrtf = Vector3.Lerp(vertrtf, new Vector3(0, 1, 0), Time.deltaTime);
            vertltb = Vector3.Lerp(vertltb, new Vector3(0, 1, 0), Time.deltaTime);
            vertrtb = Vector3.Lerp(vertrtb, new Vector3(0, 1, 0), Time.deltaTime);

            vertlbf = Vector3.Lerp(vertlbf, new Vector3(-1, -1, 1), Time.deltaTime);
            vertrbf = Vector3.Lerp(vertrbf, new Vector3(1, -1, 1), Time.deltaTime);
            vertlbb = Vector3.Lerp(vertlbb, new Vector3(-1, -1, -1), Time.deltaTime);
            vertrbb = Vector3.Lerp(vertrbb, new Vector3(1, -1, -1), Time.deltaTime);
        }
        //ramp
        if (shapeN == 2)
        {
            vertltf = Vector3.Lerp(vertltf, new Vector3(-1, -1, 2), Time.deltaTime);
            vertrtf = Vector3.Lerp(vertrtf, new Vector3(1, -1, 2), Time.deltaTime);
            vertltb = Vector3.Lerp(vertltb, new Vector3(-1, 0.5f, -1), Time.deltaTime);
            vertrtb = Vector3.Lerp(vertrtb, new Vector3(1, 0.5f,-1), Time.deltaTime);

            vertlbf = Vector3.Lerp(vertlbf, new Vector3(-1, -1, 1), Time.deltaTime);
            vertrbf = Vector3.Lerp(vertrbf, new Vector3(1, -1, 1), Time.deltaTime);
            vertlbb = Vector3.Lerp(vertlbb, new Vector3(-1, -1, -1), Time.deltaTime);
            vertrbb = Vector3.Lerp(vertrbb, new Vector3(1, -1, -1), Time.deltaTime);
        }
        // roof
        if (shapeN == 3)
        {
            vertltf = Vector3.Lerp(vertltf, new Vector3(-1, 0.2f, 0), Time.deltaTime);
            vertrtf = Vector3.Lerp(vertrtf, new Vector3(1, 0.2f, 0), Time.deltaTime);
            vertltb = Vector3.Lerp(vertltb, new Vector3(-1, 0.2f, 0), Time.deltaTime);
            vertrtb = Vector3.Lerp(vertrtb, new Vector3(1, 0.2f, 0), Time.deltaTime);

            vertlbf = Vector3.Lerp(vertlbf, new Vector3(-1, -1, 1), Time.deltaTime);
            vertrbf = Vector3.Lerp(vertrbf, new Vector3(1, -1, 1), Time.deltaTime);
            vertlbb = Vector3.Lerp(vertlbb, new Vector3(-1, -1, -1), Time.deltaTime);
            vertrbb = Vector3.Lerp(vertrbb, new Vector3(1, -1, -1), Time.deltaTime);
        }

        Start();

    }
}
