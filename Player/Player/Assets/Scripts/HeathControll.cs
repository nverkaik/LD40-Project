using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HeathControll : MonoBehaviour {

    public float MaxHealth;
    public float Health;
    public Slider HpSlider;
    public bool DestroyImmidiatly;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        HpSlider.value = Health;
        HpSlider.maxValue = MaxHealth;
	}
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "EnemyArrow")
        {
            Health -= other.gameObject.GetComponent<ArrowControll>().damage;
            if (DestroyImmidiatly)
            {
                Destroy(other.gameObject);
            }
            else
            {
                other.GetComponent<Rigidbody2D>().velocity = Vector3.zero;
                other.tag = "Useless";
                other.transform.parent = transform;
            }
        }
    }
}
