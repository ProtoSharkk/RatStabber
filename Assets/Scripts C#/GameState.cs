using UnityEngine;

public class GameState : MonoBehaviour
{
	public State state;
	public uint wave;
	public GameObject shop;
	public GameObject ratbot;
	public GameObject gunThrower;

	int[] counts = new int[2];
	enum CountIndex : uint {
		ratbot = 0,
		gunThrower = 1
	}

	void Start() {
		OpenShop();
	}

	public enum State {
		Wave,
		Shop,
		Menu,
		Paused,
	}

    // Update is called once per frame
    void Update()
    {
        if (GameObject.FindGameObjectsWithTag("Ratbot").Length == 0 
			&& state == State.Wave
		) {
			OpenShop();
		}
    }
	void OpenShop() {
		state = State.Shop;
		Instantiate(shop);
	}
	public void NewWave() {
		// Close the shop
		Destroy(GameObject.FindGameObjectWithTag("Shop"));
		// Spawn ratbots around the player
		// Amount, health, and damage scale with waves
		state = State.Wave;
		Vector3 playerPosition 
			= GameObject
			.FindGameObjectWithTag("Player")
			.transform
			.position;
		for (uint _ = 0; _ <= wave; _++) {
			GameObject newRatbot = Instantiate(
				SpawnRatbot(),
				Random.insideUnitCircle.normalized*20,
				Quaternion.identity
			);
			newRatbot.GetComponent<Ratbot>().damageStrength 
				= 5+wave*5;
			newRatbot.GetComponent<Ratbot>().health = 5+wave*2;
		}
		wave++;
	}
	public GameObject SpawnRatbot() {
		if (counts[(uint)CountIndex.gunThrower] < wave/3 
			&& wave > 3
		) {
			counts[(uint)CountIndex.gunThrower]++;
			return gunThrower;
		}
		return ratbot;
	}
}
