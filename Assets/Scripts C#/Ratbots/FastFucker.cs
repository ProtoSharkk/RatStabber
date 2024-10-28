using UnityEngine;
using System.Collections;

public class FastFucker : Ratbot
{
	bool attack = true;
	void Update() {
		if (attack)
			MoveTowardsPlayer(moveSpeed*2);
		else
			MoveAwayFromPlayer(moveSpeed);
    }
	void MoveAwayFromPlayer(float speed) {
		controller.AddRelativeForce(
			(transform.position - player.transform.position)
				.normalized
			*speed
			*Time.deltaTime
		);
	}
	new void OnCollisionStay2D (Collision2D collision) {
		base.OnCollisionStay2D(collision);
		StartCoroutine("RunAway");
	}
	IEnumerator RunAway() {
		attack = false;
		yield return new WaitForSeconds (1F);
		attack = true;
	}
	new void Damage (float hurtyAmount) {
		RunAway();
		base.Damage(hurtyAmount);
	}
}
