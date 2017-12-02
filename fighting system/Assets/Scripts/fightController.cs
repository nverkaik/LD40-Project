using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fightController : MonoBehaviour {

    #region Variables + References
    [Header("Sword Attributes")]
    public float swordDelay = .5f;
    [Header("Bow Attributes")]
    public float bowDelay = .5f;

    [Header("References")]
    public GameObject arrow;
    public Transform arrowSpawn;
    public GameObject sword;
    public GameObject swordSwing;
    public GameObject bow;

    // Values
    private float mouseX;
    private float mouseY;
    private float angle;
    public bool fightType;
    private Transform mousePos;
    private bool canFire = true;
    #endregion

    void Start () {
        sword.SetActive(true);
        bow.SetActive(false);
    }
	
	void Update () {
        mouseX = Input.mousePosition.x;
        mouseY = Input.mousePosition.y;
        //mousepos.position = Camera.main.ScreenToWorldPoint(new Vector3(mousex, mousey, 0f));
        Vector3 dir = Camera.main.ScreenToWorldPoint(new Vector3(mouseX, mouseY, 0f)) - transform.position;
        angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg ;
        Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        transform.rotation = rotation;
        if (fightType)
        {
            sword.SetActive(false);
            bow.SetActive(true);
            if (Input.GetMouseButton(0) && canFire)
            {
                canFire = false;
                Invoke("resetFire", bowDelay);
                Destroy(Instantiate(arrow, arrowSpawn.transform.position, arrowSpawn.transform.rotation), 2f);
            }

        }
        else
        {
            sword.SetActive(true);
            bow.SetActive(false);
            if (Input.GetMouseButtonDown(0))
            {
                swordSwing.SetActive(true);
                Invoke("swingEnd", swordDelay);
            }
        }
    }
    void swingEnd()
    {
        swordSwing.SetActive(false);
    }

    void resetFire()
    {
        canFire = true;
    }

}
