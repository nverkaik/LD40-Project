using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GUIController : MonoBehaviour {

    public Image SwordIMG;
    public Image BowIMG;
    public Image ArrowIMG;
    public Image Curse;
    public int CurseState;
    public GameObject Sword;
    public GameObject Bow;
    public GameObject Arrow;
    public Sprite[] CurseLevel;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        SwordIMG.sprite = Sword.GetComponent<SpriteRenderer>().sprite;
        BowIMG.sprite = Bow.GetComponent<SpriteRenderer>().sprite;
        ArrowIMG.sprite = Arrow.GetComponent<SpriteRenderer>().sprite;
        Curse.sprite = CurseLevel[CurseState];
        if (Input.GetKeyDown(KeyCode.F))
        {
            CurseState++;
        }
        if (CurseState >= 8)
        {
            CurseState = 0;
        }
    }
}
