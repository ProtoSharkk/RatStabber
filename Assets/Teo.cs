using UnityEngine;

public class Teo : MonoBehaviour
{
	public float health = 100;
	public float moveSpeed = 10;
	public float swingRange = 3;
	public float damageStrength = 10;
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

		if (Input.GetMouseButtonDown(0)) {
			RaycastHit2D[] hits = Physics2D.CircleCastAll(
				transform.position,
				swingRange,
				new Vector2(
					Screen.width/2 - Input.mousePosition.x,
					Screen.height/2 - Input.mousePosition.y
				)
			);
			foreach (RaycastHit2D hit in hits) {
				Ratbot ratbot = hit.collider.GetComponent<Ratbot>();
				if (ratbot == null) continue;
				ratbot.Damage(damageStrength);
			}
		}
	}
}
