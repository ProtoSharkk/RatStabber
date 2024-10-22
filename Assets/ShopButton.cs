using UnityEngine;

public class ShopButton : MonoBehaviour
{
	public string upgrade;
	void Start() {
		GetComponent<UnityEngine.UI.Button>().onClick.AddListener(Upgrade);
	}
	void Upgrade() {
		Teo player = GameObject.FindGameObjectWithTag("Player").GetComponent<Teo>();
		GameState gameState = 
			GameObject
			.FindGameObjectWithTag("GameController")
			.GetComponent<GameState>();
		if (upgrade == "attackRange") {
			player.swingRange += 1;
		}
		else if (upgrade == "attackDistance") {
			player.swingDistance += 0.5F;
		}
		else if (upgrade == "attackDamage") {
			player.damageStrength += 5;
		}
		else if (upgrade == "attackCooldown") {
			player.attackCooldownSeconds -= 0.5F;
		}
		else if (upgrade == "maxHealth") {
			player.health += 20;
			player.maxHealth += 20;
		}
		else 	if (upgrade == "movementSpeed") {
			player.moveSpeed += 5;
		}
		else if (upgrade == "dashDistance") {
			player.dashDistance += 1;
		}
		else if (upgrade == "dashCooldown") {
			player.dashCooldownSeconds -= 0.5F;
		}
		gameState.NewWave();
	}
}
