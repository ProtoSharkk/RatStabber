using UnityEngine;

public class AttackCooldown : MonoBehaviour
{
	Teo player;
	UnityEngine.UI.Image bar;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Teo>();
		bar = GetComponent<UnityEngine.UI.Image>();
    }

    // Update is called once per frame
    void Update()
    {
		GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, Mathf.Max(0, 100-100*(Time.fixedTime-player.lastAttackTime)/player.attackCooldownSeconds));
    }
}
