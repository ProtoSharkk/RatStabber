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
		Debug.Log(transform.position.x);
		//bar.x=200*(Time.fixedTime-player.lastAttackTime)/player.attackCooldownSeconds;
    }
}
