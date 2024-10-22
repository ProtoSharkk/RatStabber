using UnityEngine;

public class Teo : MonoBehaviour
{
	public float health = 100;
	public float maxHealth = 100;
	public float moveSpeed = 10;
	public float swingRange = 3;
	public float swingDistance = 10;
	public float damageStrength = 10;
	public float attackCooldownSeconds = 10;
	public float dashDistance = 5F;
	public float dashCooldownSeconds = 5;
	public float lastAttackTime = 0;
	public float lastDashTime = 0;
	Rigidbody2D controller;
	GameState gameState;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start() {
		controller = GetComponent<Rigidbody2D>();
		gameState = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameState>();
    }

    // Update is called once per frame
    void Update() {
		// Move player
		controller.linearVelocity = new Vector2 (
			Input.GetAxis("Horizontal"),
			Input.GetAxis("Vertical")
		).normalized * moveSpeed;
		// Attack on click if not on cooldown
		if (Input.GetMouseButtonDown(0)) {
			Attack();
			lastAttackTime = Time.fixedTime;
		}
		if (Input.GetMouseButtonDown(1)) {
			StartCoroutine("Dash");
		}
	}
	void Attack() {
		if (Time.fixedTime-lastAttackTime < attackCooldownSeconds) {
			return;
		}
		// Get all objects in range in the direction of cursor
		RaycastHit2D[] hits = Physics2D.CircleCastAll(
			transform.position,
			swingRange,
			new Vector2(
				Screen.width/2 - Input.mousePosition.x,
				Screen.height/2 - Input.mousePosition.y
			)
		);
		// Damage all ratbots in scanned area
		foreach (RaycastHit2D hit in hits) {
			Ratbot ratbot = hit.collider.GetComponent<Ratbot>();
			if (ratbot == null) continue;
			ratbot.Damage(damageStrength);
		}
	}
	void Dash() {
		if (Time.fixedTime-lastDashTime < dashCooldownSeconds) return;
		lastDashTime = Time.fixedTime;
		transform.position += new Vector3(
			Input.mousePosition.x - Screen.width/2,
			Input.mousePosition.y - Screen.height/2,
			0
		).normalized * dashDistance;
		Debug.Log(controller.linearVelocity);
	}
}
