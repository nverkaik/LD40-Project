using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkerController : MonoBehaviour
{

    public Transform Player;
    public float Speed;
    public float AgroRange;
    public float RotationSpeed;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        float distance = Vector3.Distance(transform.position, Player.position);
        if (distance < AgroRange)
        {
            Vector3 targetDir = Player.position - transform.position;
            float angle = Mathf.Atan2(targetDir.y, targetDir.x) * Mathf.Rad2Deg - 90f;
            Quaternion q = Quaternion.AngleAxis(angle, Vector3.forward);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, q, RotationSpeed);
            Vector2 MovementVector = transform.up;

            transform.parent.GetComponent<Rigidbody2D>().MovePosition(transform.parent.GetComponent<Rigidbody2D>().position + MovementVector * Time.deltaTime * Speed);
            transform.parent.GetComponent<Rigidbody2D>().isKinematic = false;

        }
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, AgroRange);
    }
}