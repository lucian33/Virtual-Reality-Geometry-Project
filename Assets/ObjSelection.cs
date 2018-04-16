using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjSelection : MonoBehaviour {

    public Vector3 rotSpeed; // the rotation speed of sample geometry in UI

    public GameObject[] geometries; // geometry collection

    public int curIdx; // current index of the seleceted geometry

	// Use this for initialization
	void Start () {

        rotSpeed = new Vector3(1.0f, 1.0f, 1.0f);

        // get all gameObjects
        geometries = GameObject.FindGameObjectsWithTag("geometry");

        curIdx = 0;
        // highlight initial obj
        toggleHighlight(curIdx);

    }
	
	// Update is called once per frame
	void Update () {

        // rotate each object 
        foreach (GameObject g in geometries) {
            g.transform.Rotate(new Vector3(0.5f, 0.5f, 0.5f));
        }

        // get input for toggle selection
        if(Input.GetKeyDown("tab") == true){
            curIdx++;
            curIdx %= geometries.Length;
            toggleHighlight(curIdx);
        }
        
	}

    // highlight the selected object 
    // when selected
    void toggleHighlight(int index) {
        // remove all emission
        for (int i = 0; i < geometries.Length; i++) {
            geometries[i].GetComponent<Renderer>().material.shader = Shader.Find("Diffuse");
        }

        // turn current on by attach 
        // self illuminate shader
        geometries[index].GetComponent<Renderer>().material.shader = Shader.Find("Self-Illumin/Outlined Diffuse");
    }
}
