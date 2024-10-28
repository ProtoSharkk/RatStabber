using UnityEngine;

public class Gun : MonoBehaviour
{
	public float damageStrength;

	void OnTriggerEnter2D (Collider2D hit) {
		// Damage player and destroy self on impact
		if (hit.tag != "Player") return;
		hit.GetComponent<Teo>().health -= damageStrength;
		Destroy(gameObject);
	}

	void Update() {
		transform.Rotate(new Vector3 (0, 0, Time.deltaTime * 1000));
	}
}
