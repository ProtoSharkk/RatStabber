using UnityEngine;

public class Creeper : Ratbot
{
	public GameObject particles;
	float countdown;

	void Update() {
		if (Vector3.Distance(player.transform.position, transform.position) > 5) {
			MoveTowardsPlayer(moveSpeed);
			float newTime = countdown + Time.deltaTime;
			countdown = Mathf.Min(newTime, 1);
		} else {
			countdown -= Time.deltaTime;
			if (countdown < 0) Explode();
		}
		transform.GetChild(0).localScale = new Vector3 (countdown * 3.5F, 0.25F, 1);
	}
	void Explode() {
		Destroy(gameObject);
		Instantiate(particles);
		if (Vector3.Distance(player.transform.position, transform.position) < 5) {
			player.GetComponent<Teo>().health -= damageStrength;
		}
	}
}
