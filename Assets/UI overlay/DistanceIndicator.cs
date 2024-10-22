using UnityEngine;

public class DistanceIndicator : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
		Teo player = GameObject.FindGameObjectWithTag("Player").GetComponent<Teo>();
		RectTransform rect = GetComponent<RectTransform>();
        rect.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, player.swingDistance*2);
        rect.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, player.swingDistance*2);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
