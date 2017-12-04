using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathController : MonoBehaviour {

    public Transform Player;
    public Transform PointsCollection;
    public GameObject SicklePath;
    public GameObject Sickle;
    public Transform[] ShootingPoints;
    public float TimeBetweenAttacks;
    public GameObject Arrow;
    public float ArrowSpeed;
    public float PointRotationRate;
    float timer;
    float timer2;
    float timer3;
    float timer4;
    float timer5;
    float timer6;
    int direction;

    // Use this for initialization
    void Start () {
        timer = TimeBetweenAttacks;
	}

    // Update is called once per frame
    void Update() {
        if (timer <= 0)
        {
            timer = TimeBetweenAttacks + Random.Range(0,TimeBetweenAttacks/2);
            int pseudorandom = (int)(Mathf.Floor(Random.Range(0, 5)));
            if (pseudorandom == 5)
            {
                pseudorandom = 4;
            }
            Attack(pseudorandom);
        }
        else
        {
            timer -= Time.deltaTime;
        }
        if (timer2 > 0)
        {
            timer2 -= Time.deltaTime;
        }
        if (timer3 > 0)
        {
            timer3 -= Time.deltaTime;
        }
        if (timer4 > 0)
        {
            timer4 -= Time.deltaTime;
        }
        if (timer5 > 0)
        {
            timer5 -= Time.deltaTime;
        }
        if (timer6 > 0)
        {
            timer6 -= Time.deltaTime;
        }



        if (timer2 <= 0f && timer3 > 0)
        {
            PointsCollection.Rotate(PointsCollection.forward * Time.deltaTime * PointRotationRate * direction);
            for (int i = 0; i < 4; i++)
            {
                BoneShooting(ShootingPoints[i]);
            }
            timer2 = 0.05f;
        }
        if (timer3 <= 0 && timer4 <= 0 && timer5 <= 0 && timer6 <= 0)
        {
            PointsCollection.rotation = Quaternion.Euler(0f, 0f, 0f);
        }
        if (timer2 <= 0f && timer4 > 0)
        {
            PointsCollection.Rotate(PointsCollection.forward * Time.deltaTime * PointRotationRate * 2 * direction);
            for (int i = 0; i < 2; i++)
            {
                BoneShooting(ShootingPoints[i]);
            }
            timer2 = 0.05f;
        }
        if (timer2 <= 0f && timer5 > 0)
        {
            PointsCollection.Rotate(PointsCollection.forward * Time.deltaTime * PointRotationRate * 2 * direction);
            for (int i = 2; i < 4; i++)
            {
                BoneShooting(ShootingPoints[i]);
            }
            timer2 = 0.05f;
        }
        if (timer2 <= 0f && timer6 > 0)
        {
            Vector3 targetDir = Player.position - PointsCollection.position;
            float angle = Mathf.Atan2(targetDir.y, targetDir.x) * Mathf.Rad2Deg - 90f;
            Quaternion q = Quaternion.AngleAxis(angle, Vector3.forward);
            PointsCollection.rotation = Quaternion.RotateTowards(PointsCollection.rotation, q, 360);
            BoneShooting(ShootingPoints[3]);

            timer2 = 0.05f;
        }

    }

    void Attack(int type)
    {
        //Sickle trowing
        if (type == 0)
        {
            Vector3 targetDir = Player.position - SicklePath.transform.position;
            float angle = Mathf.Atan2(targetDir.y, targetDir.x) * Mathf.Rad2Deg + 180;
            Quaternion q = Quaternion.AngleAxis(angle, Vector3.forward);
            SicklePath.transform.rotation = Quaternion.RotateTowards(SicklePath.transform.rotation, q, 360);
            //SicklePath.transform.rotation = Quaternion.Euler(0f,0f,Random.Range(0,360));
            Instantiate(Sickle, transform.position, transform.rotation).GetComponent<SickleControll>().Path = SicklePath;
        }
        //Shooting arrows in 4 directions
        if (type == 1)
        {
            timer3 = 2f;
            direction = (int)(Mathf.Floor(Random.Range(-1, 1)));
            if (direction == 0)
            {
                direction = 1;
            }
        }
        //Shooting arrows in 2 directions(vertical)
        if (type == 2)
        {
            direction = (int)(Mathf.Floor(Random.Range(-1, 1)));
            if (direction == 0)
            {
                direction = 1;
            }
            timer4 = 3f;
        }
        //Shooting arrows in 2 directions(horizontal)
        if (type == 3)
        {
            direction = (int)(Mathf.Floor(Random.Range(-1, 1)));
            if (direction == 0)
            {
                direction = 1;
            }
            timer5 = 3f;
        }
        //Shooting arrows at player
        if (type == 4)
        {
            timer6 = 0.3f;
        }
    }

    void BoneShooting(Transform ShootPoint)
    {
        GameObject newArrow = Instantiate(Arrow,ShootPoint.position,ShootPoint.rotation);
        newArrow.GetComponent<Rigidbody2D>().velocity = newArrow.transform.right * ArrowSpeed;
        Destroy(newArrow, 3f);
    }
}
