using UnityEngine;
using System.Collections;

public class Teo : MonoBehaviour
{
	public float health = 100;
	public float maxHealth = 100;
	public float moveSpeed = 10;
	public float swingRangeDeg = 3;
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
				Input.GetAxisRaw("Horizontal"),
				Input.GetAxisRaw("Vertical")
			).normalized * moveSpeed * Time.deltaTime);
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
		Instantiate(distanceIndicator, transform);
		// Get all objects within swingDistance of player
		Collider2D[] hits = Physics2D.OverlapCircleAll(
			transform.position,
			swingDistance
		);
		// Damage all ratbots in scanned area
		foreach (Collider2D hit in hits) {
			Ratbot ratbot = hit.GetComponent<Ratbot>();
			if (ratbot == null) continue;
			// Find the closest point on the ratbot
			Vector2 hitClosest = Physics2D.ClosestPoint(
				transform.position, hit
			);
			// If ratbot's closest point within swing range, damage it.
			// Calculate absolute difference between angles of ratbot and cursor
			if (Mathf.Abs(Mathf.Atan2(
					hitClosest.y - transform.position.y,
					hitClosest.x - transform.position.x
				) - Mathf.Atan2(
					Input.mousePosition.y - Screen.height/2,
					Input.mousePosition.x - Screen.width/2
				)) > swingRangeDeg * Mathf.Deg2Rad
			) continue;
			// Apply x^2 multiplier to damage if not fully charged
			// Just use damageStrength if fully charged
			float timeWaited = Time.fixedTime - lastAttackTime;
			ratbot.Damage(
				(timeWaited < attackCooldownSeconds)
				? Mathf.Pow(timeWaited, 2) *
					damageStrength /
					Mathf.Pow(attackCooldownSeconds, 2)
				: damageStrength
			);
		}
	}
	IEnumerator Dash() {
		BoxCollider2D collider = GetComponent<BoxCollider2D>();
		// Disable collision and linearDamping while dashing
		lastDashTime = Time.fixedTime;
		dashing = true;
		collider.enabled = false;
		controller.linearDamping = 0;
		controller.linearVelocity = Vector2.zero;
		// Apply a force to player towards mouse cursor
		controller.AddRelativeForce (new Vector2(
			Input.mousePosition.x - Screen.width/2,
			Input.mousePosition.y - Screen.height/2
		).normalized * dashDistance);
		// Wait 0.2 seconds before ending the dash
		yield return new WaitForSeconds(0.2F);
		// Re enable collision and linearDamping after dash
		dashing = false;
		controller.linearDamping = 15;
		// Push enemies away at end of dash
		foreach (Collider2D hit in Physics2D.OverlapCircleAll(
			transform.position, 3
		)) {
			if (hit.tag != "Ratbot") continue;
			hit.GetComponent<Rigidbody2D>().AddRelativeForce(
				(hit.transform.position - transform.position)
					.normalized * dashDistance
			);
		}
		// Don't take damage at end of dash
		yield return new WaitForSeconds(0.2F);
		collider.enabled = true;
	}
}
