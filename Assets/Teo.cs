using UnityEngine;

public class Teo : MonoBehaviour
{
	public float health = 100F;
	public float moveSpeed = 10F;
	Rigidbody2D controller;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start() {
		controller = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update() {
		controller.linearVelocity = new Vector2 (
			Input.GetAxis("Horizontal"),
			Input.GetAxis("Vertical")
		).normalized * moveSpeed;
	}
}
