using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyingArrows : MonoBehaviour {

    public bool DestroyImmidiatly;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    private void OnTriggerEnter2D(Collider2D other)
    {
        
        if (other.tag.Contains("Arrow"))
        {
            if (DestroyImmidiatly)
            {
                Destroy(other.gameObject);
            }
            else
            {
                other.GetComponent<Rigidbody2D>().velocity = Vector3.zero;
                other.tag = "Useless";
            }
        }
    }
}
