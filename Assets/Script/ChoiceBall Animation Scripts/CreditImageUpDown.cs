using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CreditImageUpDown : MonoBehaviour {
	//public Image creditimg;
	// Use this for initialization
	void Start () {
	
	}
	private int c=-140;
	// Update is called once per frame
	void Update () {
		if (c <= 200) {
			transform.position = new Vector3 ( transform.position.x, c, 0);
			c+=4;
		}
	
	}
}
