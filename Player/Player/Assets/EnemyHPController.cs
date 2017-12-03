using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHPController : MonoBehaviour {

    public Slider EnemyHPSlider;
    public int EnemyHP;
    public int EnemyMaxHP;
    public Transform canvas;

    // Use this for initialization
    void Start () {
        EnemyHPSlider.value = EnemyHP;
        EnemyHP = EnemyMaxHP;
        EnemyHPSlider.maxValue = EnemyMaxHP;
    }
	
	// Update is called once per frame
	void Update () {
        EnemyHPSlider.value = EnemyHP;
        EnemyHPSlider.maxValue = EnemyMaxHP;
        canvas.position = transform.position;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag.Contains("Player"))
        {
            EnemyHP -= other.gameObject.GetComponent<DamageController>().damage;
            if (other.tag.Contains("Arrow"))
            {
                other.tag = "Useless";
                other.transform.parent = transform;
                other.GetComponent<Rigidbody2D>().velocity = Vector3.zero;

                //Destroy(other.gameObject);
            }
            if (EnemyHP <=0)
            {
                Destroy(canvas.gameObject);
                Destroy(gameObject);
            }
        }
    }
}
