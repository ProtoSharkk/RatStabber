using UnityEngine;
using System.Collections;

public class Creeper : Ratbot
{
	float countdown;

	void Update() {
		if (Vector3.Distance(player.transform.position, transform.position) > 5) {
			MoveTowardsPlayer(moveSpeed);
			float newTime = countdown + Time.deltaTime;
			countdown = (newTime < 1) ? newTime : 1;
		} else {
			countdown -= Time.deltaTime;
			if (countdown < 0) Explode();
		}
	}
	void Explode() {
		Destroy(gameObject);
	}
}
