using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    [Header("Player Attributes")]
    public float Speed = 10f;

    private Rigidbody2D rb;

	// Use this for initialization
	void Start () {
        rb = gameObject.GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        Vector2 movementVector = new Vector3(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));

        rb.MovePosition(rb.position + movementVector * Speed * Time.deltaTime);
	}
}
