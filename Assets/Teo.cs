using UnityEngine;

public class Teo : MonoBehaviour
{
	public float health = 100;
	public float moveSpeed = 10;
	Rigidbody2D controller;
	GameState gameState;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start() {
		controller = GetComponent<Rigidbody2D>();
		gameState = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameState>();
    }

    // Update is called once per frame
    void Update() {
		controller.linearVelocity = new Vector2 (
			Input.GetAxis("Horizontal"),
			Input.GetAxis("Vertical")
		).normalized * moveSpeed;
	}
}
