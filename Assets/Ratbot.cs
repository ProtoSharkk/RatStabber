using UnityEngine;

public class Ratbot : MonoBehaviour
{
	public float moveSpeed;
	public float damageStrength;
	public float damageTimeoutSeconds;
	public float health = 10;
	float lastDamageTime;
	GameState gameState;
	GameObject player;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
		player = GameObject.FindGameObjectWithTag("Player");
		gameState = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameState>();
    }

    // Update is called once per frame
    void Update()
    {
		Rigidbody2D controller = GetComponent<Rigidbody2D>();
		Vector2 direction = (player.transform.position - transform.position).normalized;
		controller.linearVelocity = direction*moveSpeed;
    }
	void OnCollisionStay2D(Collision2D collision) {
		// Deal damage when colliding with the player on a 0.5 second cooldown
		if (collision.gameObject.tag != "Player") return;
		if (lastDamageTime > Time.fixedTime-damageTimeoutSeconds) return;
		lastDamageTime = Time.fixedTime;
		collision.gameObject.GetComponent<Teo>().health -= damageStrength;
	}
	public void Damage(float hurtyAmount) {
		health -= hurtyAmount;
		if (health <= 0) {
			Destroy(gameObject);
		}
	}
}
