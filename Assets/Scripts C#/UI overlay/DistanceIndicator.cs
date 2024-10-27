using UnityEngine;
using System.Collections;

public class DistanceIndicator : MonoBehaviour
{
	public float multiplier;
	Teo player;
	SpriteRenderer sprite;
	float timeCreated;
    void Start() {
		player = GameObject.FindGameObjectWithTag("Player").GetComponent<Teo>();
		sprite = GetComponent<SpriteRenderer>();
		timeCreated = Time.fixedTime;
		transform.localScale = new Vector3 (player.swingDistance*multiplier, player.swingDistance*multiplier, 1);
		StartCoroutine("KillMyself");
    }

	void Update() {
		sprite.color = new Color (0F, 0F, 0F, 0.5F-(Time.fixedTime-timeCreated));
	}

	IEnumerator KillMyself() {
		yield return new WaitForSeconds (0.5F);
		Destroy(gameObject);
	}
}
