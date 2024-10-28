using UnityEngine;

public class Ratbot : MonoBehaviour
{
	public float moveSpeed;
	public float damageStrength;
	public float damageTimeoutSeconds;
	public float health = 10;
	float lastDamageTime;

	public static GameState gameState;
	public static GameObject player;
	public Rigidbody2D controller;

    void Start() {
		SetVars();
    }

	public void SetVars() {
		controller = GetComponent<Rigidbody2D>();
		// Set gameState and player objects
		player = GameObject.FindGameObjectWithTag("Player");
		gameState = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameState>();
	}

    void Update() {
		MoveTowardsPlayer(moveSpeed);
    }

	public void MoveTowardsPlayer(float speed) {
		controller.AddRelativeForce(
			(player.transform.position - transform.position)
				.normalized
			*speed
			*Time.deltaTime
		);
	}

	public virtual void OnCollisionStay2D(Collision2D collision) {
		// Deal damage when colliding with the player on a 0.5 second cooldown
		if (collision.gameObject.tag != "Player") return;
		if (lastDamageTime > Time.fixedTime-damageTimeoutSeconds) return;
		lastDamageTime = Time.fixedTime;
		collision.gameObject.GetComponent<Teo>().health -= damageStrength;
	}

	// Die if health below zero
	public void Damage(float hurtyAmount) {
		health -= hurtyAmount;
		if (health <= 0) {
			Destroy(gameObject);
		}
	}
}
