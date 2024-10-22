using UnityEngine;
using System.Collections;

public class DistanceIndicator : MonoBehaviour
{
	public float multiplier;
	Teo player;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
		player= GameObject.FindGameObjectWithTag("Player").GetComponent<Teo>();
		transform.localScale = new Vector3 (player.swingDistance*multiplier, player.swingDistance*multiplier, 1);
		StartCoroutine("KillMyself");
    }

	IEnumerator KillMyself () {
		yield return new WaitForSeconds (0.5F);
		Destroy(gameObject);
	}
}
