using UnityEngine;

public class Teo : MonoBehaviour
{
	public float moveSpeed = 10F;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
		Rigidbody2D controller = GetComponent<Rigidbody2D>();
		controller.linearVelocity = new Vector2 (
			Input.GetAxis("Horizontal"),
			Input.GetAxis("Vertical")
		).normalized * moveSpeed;
	}
}
