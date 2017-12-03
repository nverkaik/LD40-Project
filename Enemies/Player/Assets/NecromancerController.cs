using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NecromancerController : MonoBehaviour {

    public Transform Player;
    public GameObject[] SpawnEnemies;
    public GameObject arrow;
    public Transform[] Spawnpoints;
    public float DelayBetweenAttacks;
    private float timer;
    public float ArrowSpeed;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (timer <= 0)
        {
            timer = DelayBetweenAttacks;
            int attack = (int)Mathf.Floor(Random.value * 2);
            if (attack == 2)
            {
                attack = 1;
            }
            StartAttack(attack);
        }
        else
        {
            timer -= Time.deltaTime;
        }
	}
    void StartAttack(int attacktype)
    {
        //summon skeletons
        if (attacktype == 0)
        {
            foreach (Transform spawnpoint in Spawnpoints)
            {
                if (Random.Range(0,100) <= 25)
                {
                    int enemy = (int)Mathf.Floor(Random.value * 2);
                    if (enemy == 2)
                    {
                        enemy = 1;
                    }
                    Instantiate(SpawnEnemies[enemy], spawnpoint.position, spawnpoint.rotation).GetComponent<EnemyHPControll>().Player = Player;
                }


            }
           
        }
        //shoot bones
        if (attacktype == 1)
        {
            for (int i = 0; i < (int)Mathf.Floor(Random.Range(7, 13)); i++)
            {
                Quaternion q = Quaternion.Euler(0f,0f,Random.Range(0, 360));
                GameObject newarrow = Instantiate(arrow, transform.position, q);
                newarrow.GetComponent<Rigidbody2D>().velocity = newarrow.transform.right * ArrowSpeed;
                Destroy(newarrow, 4f);
            }
        }
    }
}
