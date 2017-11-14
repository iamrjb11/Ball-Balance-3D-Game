using UnityEngine;
using System.Collections;

public class BallMoving : MonoBehaviour {

	void Update () {
		transform.Rotate (new Vector3(30,0,0)*Time.deltaTime);
	
	}
}
