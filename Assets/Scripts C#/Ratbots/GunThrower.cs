using UnityEngine;

public class GunThrower : Ratbot
{
	public GameObject gun;
	public float throwSpeed;

	void Start() {
		SetVars();
		InvokeRepeating(
			"ThrowGun",
			Random.Range(1, 3),
			Random.Range(1, 3)
		);
	}

	void ThrowGun() {
		GameObject thrown = Instantiate(
			gun,
			transform.position,
			Quaternion.identity
		);
		thrown.GetComponent<Rigidbody2D>().AddRelativeForce((
			player.transform.position - thrown.transform.position
		).normalized * throwSpeed);
		thrown.GetComponent<Gun>().damageStrength = damageStrength;
	}
}
