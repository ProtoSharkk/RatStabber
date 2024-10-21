using UnityEngine;

public class GameState : MonoBehaviour
{
	public string state;
	public uint wave;
	public GameObject ratbot;
	public GameObject shop;
	void Start() {
		OpenShop();
	}

    // Update is called once per frame
    void Update()
    {
        if (GameObject.FindGameObjectsWithTag("Ratbot").Length == 0 && state == "WAVE") {
			OpenShop();
		}
    }
	void OpenShop() {
		state = "SHOP";
		Instantiate(shop);
	}
	public void NewWave() {
		// Close the shop
		Destroy(GameObject.FindGameObjectWithTag("Shop"));
		// Spawn ratbots around the player
		// Amount, health, and damage scale with waves
		state = "WAVE";
		Vector3 playerPosition = GameObject.FindGameObjectWithTag("Player").transform.position;
		for (uint _ = 0; _ <= wave; _++) {
			GameObject newRatbot = Instantiate(
				ratbot,
				Random.insideUnitCircle.normalized*20,
				Quaternion.identity
			);
			newRatbot.GetComponent<Ratbot>().damageStrength = 5+wave*5;
			newRatbot.GetComponent<Ratbot>().health = 5+wave*2;
		}
		wave++;
	}
}
