using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shoot : MonoBehaviour {

    public float arrowforce;
    // Use this for initialization
    void Start () {
        GetComponent<Rigidbody2D>().AddForce(transform.right * arrowforce);
    }
	
	// Update is called once per frame
	void FixedUpdate () {
        
    }
}
