using UnityEngine;

public class DistanceIndicator : MonoBehaviour
{
	Teo player;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
		player= GameObject.FindGameObjectWithTag("Player").GetComponent<Teo>();
    }

    // Update is called once per frame
    void Update()
    {
		Debug.Log(player.swingDistance);
		transform.localScale = new Vector3 (player.swingDistance*0.2F, player.swingDistance*0.2F, 1);
    }
}
