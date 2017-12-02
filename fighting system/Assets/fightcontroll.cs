using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fightcontroll : MonoBehaviour {

    public GameObject arrow;
    public Transform arrowspawn;
    public GameObject sword;
    public GameObject swordswing;
    public GameObject bow;
    float mousex;
    float mousey;
    float angle;
    public bool fighttype;
    Transform mousepos;
    // Use this for initialization
    void Start () {
        sword.SetActive(true);
        bow.SetActive(false);
    }
	
	// Update is called once per frame
	void Update () {
        mousex = Input.mousePosition.x;
        mousey = Input.mousePosition.y;
        //mousepos.position = Camera.main.ScreenToWorldPoint(new Vector3(mousex, mousey, 0f));
        Vector3 dir = Camera.main.ScreenToWorldPoint(new Vector3(mousex, mousey, 0f)) - transform.position;
        angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg ;
        Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        transform.rotation = rotation;
        if (fighttype)
        {
            sword.SetActive(false);
            bow.SetActive(true);
            if (Input.GetMouseButtonDown(0))
            {
                Destroy(Instantiate(arrow, arrowspawn.transform.position, arrowspawn.transform.rotation), 2f);
            }

        }
        else
        {
            sword.SetActive(true);
            bow.SetActive(false);
            if (Input.GetMouseButtonDown(0))
            {
                swordswing.SetActive(true);
                Invoke("swingend", 0.5f);
            }
        }
    }
    void swingend()
    {
        swordswing.SetActive(false);
    }
}
