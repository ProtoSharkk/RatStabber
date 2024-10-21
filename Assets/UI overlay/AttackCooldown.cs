using UnityEngine;

public class AttackCooldown : MonoBehaviour
{
	Teo player;
	TMPro.TMP_Sprite bar;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Teo>();
    }

    // Update is called once per frame
    void Update()
    {
    }
}
