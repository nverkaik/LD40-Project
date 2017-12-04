using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SickleControll : MonoBehaviour {

    public float SickleSpeed;
    public float SickleRotationRate;
    public GameObject Path;
    public Transform PartToRatate;
    Transform[] Points;
    float speed;
    int targetId;
    Transform target;
    bool Ending = false;

    void Start () {
        Points = Path.GetComponent<PathControll>().Points;
        target = Points[0];
        speed = SickleSpeed;
	}

    // Update is called once per frame
    void Update()
    {
        PartToRatate.Rotate(PartToRatate.forward * Time.deltaTime * SickleRotationRate);

        Vector2 dir = target.position - transform.position;
        transform.Translate(dir.normalized * speed * Time.deltaTime);
        if (Vector2.Distance(transform.position, target.position) <= 0.2f)
        {
            if (targetId + 1 == Points.Length)
            {
                targetId = 0;
                Ending = true;
                target = Points[targetId];
                //transform.position = Points[0].position;
            }
            else
            {
                targetId++;
                target = Points[targetId];
            }
        }
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.name == "Death" && Ending)
        {
            Destroy(gameObject);
        }
    }
}
