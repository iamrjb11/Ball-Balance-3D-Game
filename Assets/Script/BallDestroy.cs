using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class BallDestroy : MonoBehaviour {
	public GameObject Ball;

	public uManager ui;

	public Image[] img;
	//private static int c=1;
	public static int loadinglevel = 2;

	void Start () {
		if (ui.getLifeShowProblemValue () == 1) {  //Mane LifeShowProblem=1 mane Camera at present Menu Image a ase (So life Re-Charge Hobe)
			loadinglevel = 2;
		}
		if (loadinglevel == 2) {
			img [0].gameObject.SetActive (true);
			img [2].gameObject.SetActive (true);

		}
		else if (loadinglevel== 1) {
			img [0].gameObject.SetActive (false);
			img [1].gameObject.SetActive (true);
			//c = 0;
		}

	}
	
	void Update () {
	}

	void OnCollisionEnter(Collision col){
		if (col.gameObject.tag == "Ball_Destroy") {
			Destroy (col.gameObject);
	
			// For Load Level
			loadinglevel--;
			if (loadinglevel != 0 && ui.getStartBallRunValue() != 0 && ui.getGameLevelValue() ==0) {
				//ui.setMusic ();
				Application.LoadLevel (0);
			}
			else if (loadinglevel != 0 && ui.getStartBallRunValue() != 0 && ui.getGameLevelValue() ==1) {
				//ui.setMusic ();
				Application.LoadLevel (1);
			}
			else { 
				// Last Part of Life 
				img [0].gameObject.SetActive (false);
				img [1].gameObject.SetActive (true);
				img [2].gameObject.SetActive (false);
				img [3].gameObject.SetActive (true);
				loadinglevel = 2;
				ui.GameOverMenu ();
			}
		}
		if (col.gameObject.tag == "GameOverPoint") {
			ui.WinMenu ();
		}
	}
}
