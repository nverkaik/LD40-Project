using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour {

    public Transform Player;
    public float Speed;
    public float ShootRange;
    public float AgroRange;
    public float RotationSpeed;
    public GameObject Arrow;
    public float ArrowSpeed;
    public bool Walking;
    public Transform ShootingPoint;
    public float ShootngTimer;
    float timer;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (timer <= 0)
        {
            timer = ShootngTimer;
        }
        else
        {
            timer -= Time.deltaTime;
        }

        float distance = Vector3.Distance(transform.position, Player.position);
        if (distance < AgroRange)
        {
            Vector3 targetDir = Player.position - transform.position;
            float angle = Mathf.Atan2(targetDir.y, targetDir.x) * Mathf.Rad2Deg - 90f;
            Quaternion q = Quaternion.AngleAxis(angle, Vector3.forward);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, q, 40);
            if (distance < ShootRange && Walking == false)
            {
                if (timer <= 0)
                {
                    GameObject newArrow = Instantiate(Arrow, ShootingPoint.position, Quaternion.AngleAxis(angle + 90f, Vector3.forward));
                    newArrow.GetComponent<Rigidbody2D>().velocity = transform.up * ArrowSpeed;
                    Destroy(newArrow, 4f);
                }
            }
            else
            {
                transform.Translate(Vector3.up * Time.deltaTime * Speed);
            }
        }
        if (timer <= 0)
        {
            timer = ShootngTimer;
        }
        else
        {
            timer -= Time.deltaTime;
        }
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, AgroRange);
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, ShootRange);
    }
}