using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class BallControl : MonoBehaviour {
	public float Ball_Speed;
	public float Balance_Speed;

	private Rigidbody rb;
	public Text Scores;
	static int saveFirstLevelScores = 0;
	private int countScores;
	public uManager ui;
	///Selete Touch Button
	static int SeleteTouchButtonValue = 0;
	public Button[] TouchButton;

	/// Choice Ball Option
	public Camera_Control CC;
	static int ChoiceBallValue=0;
	public Material[] BallMaterials;


	private bool onGround,IsLeft,IsRight;

	void Start () {
		IsLeft = IsRight = false;
		/// Selete the ball Material ( By Checked )
		if (CC.getChoiceBallValue() == 0) {
			GetComponent<Renderer> ().material = BallMaterials [0];
		}
		else if (CC.getChoiceBallValue() == 1) {
			GetComponent<Renderer> ().material = BallMaterials [1];
		}
		else if (CC.getChoiceBallValue() == 2) {
			GetComponent<Renderer> ().material = BallMaterials [2];
		}
		else if (CC.getChoiceBallValue() == 3) {
			GetComponent<Renderer> ().material = BallMaterials [3];
		}
		else if (CC.getChoiceBallValue() == 4) {
			GetComponent<Renderer> ().material = BallMaterials [4];
		}
		rb = GetComponent<Rigidbody> ();
		onGround = true;
		countScores = 0;
		Scores.text = countScores.ToString ();
		///For Option Selete Control
		SeleteTouchButtonValue = ui.getTouchButtonValue ();
		if (SeleteTouchButtonValue == 1) {
			TouchButton [0].gameObject.SetActive (true);
			TouchButton [1].gameObject.SetActive (true);
		}
		else {
			TouchButton [0].gameObject.SetActive (false);
			TouchButton [1].gameObject.SetActive (false);
		}
		//Scores 
		if (ui.getGameLevelValue() == 1) {
			countScores = saveFirstLevelScores;
		}
	}

	void Update () {
		if (ui.getStartBallRunValue () == 1) {
			if (SeleteTouchButtonValue == 0) {

				float Control = Input.acceleration.x * Balance_Speed;
				rb.AddForce (new Vector3 (Control,0, Ball_Speed * Time.deltaTime));
			} 
			else {
				if(IsLeft) 
					rb.AddForce (new Vector3 (-7f,0, Ball_Speed * Time.deltaTime));

				if (IsRight) 
					rb.AddForce (new Vector3 (7f,0, Ball_Speed * Time.deltaTime));
				//Auto Ball Running
				else rb.AddForce (new Vector3 (0,0, Ball_Speed * Time.deltaTime));

			}
		}
	}
	//For Jump
	public void Jump(){
		if (onGround) {
			rb.AddForce (0, 320, 0);
			onGround = false;
		}
	}

	void OnTriggerEnter(Collider collider){
		if (collider.gameObject.tag == "Coin_Destroy") {
			collider.gameObject.SetActive (false);

			countScores += 10;
			Scores.text = countScores.ToString ();
			ui.CollecteScores(countScores.ToString ());
		}
	}

	public void SaveScoresFirstLevel(){
		saveFirstLevelScores = countScores;
	}
	void OnCollisionEnter(Collision col){
		if (col.gameObject.tag == "Ground") {
			onGround = true;
		}
		if (col.gameObject.tag == "GoalPointLevel1") {
			ui.GoalPointLevel1 ();
		}
		if (col.gameObject.tag == "GoalPointLevel2") {
			ui.WinMenu ();
		}
	}
	//Choice Ball Option -> Selete the Ball kono kaje lagbe nahh
	public void Done(){
		ChoiceBallValue= CC.getChoiceBallValue ();
		//Application.LoadLevel (2);
	}
	public void BackOptionMenu(){
		//Application.LoadLevel (2);
	}
	//Control Tauch Button
	public void DownLeftButton(){
		IsLeft = true;
	}
	public void UpLeftButton(){
		IsLeft = false;
	}
	public void DownRightButton(){
		IsRight = true;
	}
	public void UpRightButton(){
		IsRight = false;
	}
}
