using UnityEngine;
using System.Collections;

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
	public GameObject distanceIndicator;
	Rigidbody2D controller;
	GameState gameState;
	bool dashing;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start() {
		controller = GetComponent<Rigidbody2D>();
		gameState = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameState>();
    }

    // Update is called once per frame
    void Update() {
		// Move player
		if (!dashing) {
			controller.AddRelativeForce (new Vector2 (
				Input.GetAxis("Horizontal"),
				Input.GetAxis("Vertical")
			).normalized * moveSpeed);
		}
		// Attack on click if not on cooldown
		if (Input.GetMouseButtonDown(0)) {
			Attack();
			lastAttackTime = Time.fixedTime;
		}
		if (Input.GetMouseButtonDown(1) && Time.fixedTime-lastDashTime > dashCooldownSeconds) {
			StartCoroutine("Dash");
		}
	}
	void Attack() {
		if (Time.fixedTime-lastAttackTime < attackCooldownSeconds) {
			return;
		}
		Instantiate(distanceIndicator, transform);
		// Get all objects in range in the direction of cursor
		RaycastHit2D[] hits = Physics2D.CircleCastAll(
			transform.position,
			swingRange,
			new Vector2(
				Input.mousePosition.x - Screen.width/2,
				Input.mousePosition.y - Screen.height/2
			).normalized,
			swingDistance
		);
		// Damage all ratbots in scanned area
		foreach (RaycastHit2D hit in hits) {
			Ratbot ratbot = hit.collider.GetComponent<Ratbot>();
			if (ratbot == null) continue;
			ratbot.Damage(damageStrength);
		}
	}
	IEnumerator Dash() {
		BoxCollider2D collider = GetComponent<BoxCollider2D>();
		lastDashTime = Time.fixedTime;
		dashing = true;
		collider.enabled = false;
		controller.linearDamping = 0;
		controller.linearVelocity = Vector2.zero;
		controller.AddRelativeForce (new Vector2(
			Input.mousePosition.x - Screen.width/2,
			Input.mousePosition.y - Screen.height/2
		).normalized * dashDistance);
		yield return new WaitForSeconds(0.2F);
		dashing = false;
		collider.enabled = true;
		controller.linearDamping = 15;
	}
}
