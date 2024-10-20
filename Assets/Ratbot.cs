using UnityEngine;

public class Ratbot : MonoBehaviour
{
	public float moveSpeed;
	GameObject player;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
		player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
		Rigidbody2D controller = GetComponent<Rigidbody2D>();
		Vector2 direction = (player.transform.position - transform.position).normalized;
		controller.linearVelocity = direction*moveSpeed;
    }
}
