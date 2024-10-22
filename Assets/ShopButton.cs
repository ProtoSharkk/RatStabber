using UnityEngine;

public class ShopButton : MonoBehaviour
{
	public UpgradeOption upgrade;
	public float amount;
	public enum UpgradeOption {
		AttackRange,
		AttackDistance,
		AttackDamage,
		AttackCooldown,
		MaxHealth,
		MovementSpeed,
		DashDistance,
		DashCooldown
	}
	void Start() {
		GetComponent<UnityEngine.UI.Button>().onClick.AddListener(Upgrade);
	}
	void Upgrade() {
		Teo player = GameObject.FindGameObjectWithTag("Player").GetComponent<Teo>();
		switch (upgrade) {
			case UpgradeOption.AttackRange:
				player.swingRange += amount;
				break;
			case UpgradeOption.AttackDistance:
				player.swingDistance += amount;
				break;
			case UpgradeOption.AttackDamage:
				player.damageStrength += amount;
				break;
			case UpgradeOption.AttackCooldown:
				player.attackCooldownSeconds += amount;
				break;
			case UpgradeOption.MaxHealth:
				player.health += amount;
				player.maxHealth += amount;
				break;
			case UpgradeOption.MovementSpeed:
				player.moveSpeed += amount;
				break;
			case UpgradeOption.DashDistance:
				player.dashDistance += amount;
				break;
			case UpgradeOption.DashCooldown:
				player.dashCooldownSeconds += amount;
				break;
		}
	}
}
