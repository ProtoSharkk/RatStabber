using UnityEngine;

public class Sword : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
		// Point sword towards mouse cursor with garbage trig
		transform.rotation = Quaternion.Euler(
			new Vector3 (0, 0, Mathf.Atan2(
				Screen.height/2 - Input.mousePosition.y,
				Screen.width/2 - Input.mousePosition.x
			) * Mathf.Rad2Deg + 135)
		);
	}
	void Swing() {
	}
}
