using UnityEngine;

public class Teo : MonoBehaviour
{
	public float moveSpeed = 10F;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
		transform.Translate(
			Input.GetAxis("Horizontal")*moveSpeed*Time.deltaTime,
			Input.GetAxis("Vertical")*moveSpeed*Time.deltaTime,
			0
		);
	}
}
