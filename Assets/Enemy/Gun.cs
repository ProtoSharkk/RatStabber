using UnityEngine;

public class Gun : MonoBehaviour
{
	public float damageStrength;
	void OnTriggerEnter2D (Collider2D hit) {
		if (hit.tag == "Player") {
			hit.GetComponent<Teo>().health -= damageStrength;
		}
	}
}
