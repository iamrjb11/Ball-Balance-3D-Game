using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class Camera_Control : MonoBehaviour {
	/// Ball
	public GameObject Ball;
	///For Control Camera
	Vector3 offset,MainCamera;
	int  CameraPosition=1000;
	/// Option -> Choice Ball -> Seleted
	public uManager ui;
	static int ChoiceBallValueSet=0;
	public Image[] ChoiceBall;

	void Start () {
		MainCamera = transform.position;
		offset = transform.position - Ball.transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		if (ui.getStartBallRunValue () == 1) {
			transform.position = Ball.transform.position + offset;
		}
	}
	///Choice Ball Option (Control Camera & Seleted Ball )
	public void ChoiceBallOption(){
		ChoiceBall [0].gameObject.SetActive (false); //Option Menu
		ChoiceBall [1].gameObject.SetActive (false);//Game Screen Tools
		ChoiceBall [2].gameObject.SetActive (true);//ChoiceBall Tools
		offset = new Vector3 (1000,7,3);

		transform.position = offset;

		ChoiceBallValueSet = 0;
		//CameraPosition = offset;
		//print (transform.position);
	}
	//Choice Ball Option (Ok Button)
	public void OKChoiceBallOption(){
		ChoiceBall [0].gameObject.SetActive (true); //Option Menu
		ChoiceBall [1].gameObject.SetActive (true); //Game Screen Tools
		ChoiceBall [2].gameObject.SetActive (false);//ChoiceBall Tools
		transform.position = MainCamera;
	}
	public void NextCameraPosition(){
		if (CameraPosition != 1120) {
			CameraPosition = CameraPosition + 30;
			offset = new Vector3 (CameraPosition, 7, 3);
			transform.position = offset;
		}
		if (ChoiceBallValueSet != 4) {
			ChoiceBallValueSet++;
		}
	}
	public void PreCameraPosition(){
		if (CameraPosition != 1000) {
			CameraPosition = CameraPosition -30;
			offset = new Vector3 (CameraPosition, 7, 3);
			transform.position = offset;
		}
		if (ChoiceBallValueSet != 0) {
			ChoiceBallValueSet--;
		}
	}
	/// Return ChoiceBallValueSet Value to BallControl Script 
	public int getChoiceBallValue(){
		return ChoiceBallValueSet;
	}
}
