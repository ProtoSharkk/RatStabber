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

    void Start() {
		SetVars();
    }

	public void SetVars() {
		// Set gameState and player objects
		player = GameObject.FindGameObjectWithTag("Player");
		gameState = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameState>();
	}

    void Update() {
		MoveTowardsPlayer();
    }

	public void MoveTowardsPlayer() {
		Rigidbody2D controller = GetComponent<Rigidbody2D>();
		Vector2 direction = (player.transform.position - transform.position).normalized;
		controller.AddRelativeForce(direction*moveSpeed*Time.deltaTime);
	}

	void OnCollisionStay2D(Collision2D collision) {
		// Deal damage when colliding with the player on a 0.5 second cooldown
		if (collision.gameObject.tag != "Player") return;
		if (lastDamageTime > Time.fixedTime-damageTimeoutSeconds) return;
		lastDamageTime = Time.fixedTime;
		collision.gameObject.GetComponent<Teo>().health -= damageStrength;
	}

	// Die if health below zero
	public void Damage(float hurtyAmount) {
		Debug.Log(hurtyAmount);
		health -= hurtyAmount;
		if (health <= 0) {
			Destroy(gameObject);
		}
	}
}
