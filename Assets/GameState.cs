using UnityEngine;

public class GameState : MonoBehaviour
{
	public string state;
	public uint wave = 1;
	public GameObject ratbot;
	void Start() {
		NewWave();
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
		NewWave();
	}
	void CloseShop() {
		
	}
	public void NewWave() {
		state = "WAVE";
		Vector3 playerPosition = GameObject.FindGameObjectWithTag("Player").GetComponent<Teo>().transform.position;
		for (uint _ = 0; _ < wave; _++) {
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
