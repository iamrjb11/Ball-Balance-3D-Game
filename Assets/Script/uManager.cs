using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class uManager : MonoBehaviour {
	static int GameLevelValue=0;
	public Image[] OtherMenu;
	public Text[] GameOverScores;
	private string collecteScores;
	static int StartBallRun=0;
	static int playproblem=0;
	static int MenuImageShowProblem=0;//Menu Image kokhon show korbe/korbe nahh

	static int LifeShowProblem=0;

	static int SeleteTouchButton = 0;
	///Music Selete
	public Add_Music[] addmusic;
	static int MusicSelete=0;
	//Scores
	public BallControl Ball;
	void Awake(){
		if (MusicSelete == 0 ) {
			addmusic [0].gameSound.Play (); //Menu Music
		} 
		else if (MusicSelete == 1 ) {
			addmusic [1].gameSound.Play ();  //Game Music
		} 
		else{
			addmusic [0].gameSound.Stop ();
			addmusic [1].gameSound.Stop ();
		}
	}
	public void MusicOnOffButton(){
		if (MusicSelete == 0 || MusicSelete == 1) {
			MusicSelete = 2;
			addmusic [0].gameSound.Stop ();
			addmusic [1].gameSound.Stop ();
		} else {
			MusicSelete = 0;
			addmusic [0].gameSound.Play ();
		}
	}
	void Start () {
		LifeShowProblem = 0; //Mane Camera at present game Level a ase (life/life--)
		if (MenuImageShowProblem == 1) {
			OtherMenu [2].gameObject.SetActive (false);
		}
	}

	public void CollecteScores(string scores){
		GameOverScores[0].text ="You Lost Scores : "+ scores; //Game Over - scores
		GameOverScores[1].text ="You Win Scores : "+ scores; //Win Image - scores
	}
	
	public void Play(){
		addmusic [0].gameSound.Stop ();
		if (MusicSelete != 2) {
			MusicSelete = 1;
			addmusic [1].gameSound.Play ();
		}
		StartBallRun = 1; //Play Button a click korle BallControl Script a Ball Run korbe
		MenuImageShowProblem = 1;///For Load Level a Menu Image na pai(BallDestroy Script er Loading er jonno)
		OtherMenu [1].gameObject.SetActive (false); ///GameOverMenu Option (Jodi Thake)
		OtherMenu [2].gameObject.SetActive (false); /// MainMenu
	}

	public void Option(){
		OtherMenu [2].gameObject.SetActive (false);
		OtherMenu [3].gameObject.SetActive (true);
	}
	public void Exit(){
		Application.Quit ();
	}
	
	public void Pause () {
		if (Time.timeScale == 1) {
			Time.timeScale = 0;
			OtherMenu[0].gameObject.SetActive(true);
		}
		else if(Time.timeScale==0){
			Time.timeScale = 1;
			OtherMenu[0].gameObject.SetActive(false);
		}
	}
	public void MainMenu(){
		Time.timeScale = 1;
		
		StartBallRun = 0; //Time Ok thakleO Ball Run korbe nahh BallControl Script a (CZ StartBallRun=0)
		MenuImageShowProblem = 0; ///For Loading Level a Menu Image Pai
		LifeShowProblem= 1; //Mane LifeShowProblem=1 mane Camera at present Menu Image a ase (So life Re-Charge Hobe)
		//For Music
		if (MusicSelete != 2)
			MusicSelete = 0;

		Application.LoadLevel (0);
	}
	/*public void BackMainMenu(){
		OtherMenu [0].gameObject.SetActive (false); /// Pause Option
		OtherMenu [1].gameObject.SetActive (false); /// GameOverMenu Option
		OtherMenu [3].gameObject.SetActive (false); /// Option
		StartBallRun=0;
		LifeShowProblem= 1;

		//For Music
		OtherMenu [2].gameObject.SetActive (true);
		Time.timeScale = 1;
	}*/
	public void Resume () {
		if (Time.timeScale == 0) {
			Time.timeScale = 1;
		}
		OtherMenu[0].gameObject.SetActive(false);
	}
	public void Replay(){
		GameLevelValue = 0;
		Application.LoadLevel (0);
	}
	///Option PBLM
	public void ChoiceBallOption(){
		OtherMenu [3].gameObject.SetActive (false); //option
	}
	public void ControlMenu(){
		OtherMenu [3].gameObject.SetActive (false); //option
		OtherMenu [4].gameObject.SetActive (true); //control
	}
	public void OptionBack(){
		Application.LoadLevel (0);
	}
	/// Control Options
	public void OptionControl_AccelerationButton(){
		SeleteTouchButton = 0;
		OtherMenu [4].gameObject.SetActive (false);  // Control
		OtherMenu [3].gameObject.SetActive (true);  // Option
	}
	public void OptionControl_TouchButton(){
		SeleteTouchButton = 1;
		OtherMenu [4].gameObject.SetActive (false);
		OtherMenu [3].gameObject.SetActive (true);
	}
	public void OptionControl_BackButton(){
		OtherMenu [4].gameObject.SetActive (false);
		OtherMenu [3].gameObject.SetActive (true);
	}
	public int getTouchButtonValue(){
		return SeleteTouchButton;
	}
	//Game Over Tools
	public void GameOverMenu(){
		OtherMenu[1].gameObject.SetActive(true);
	}
	public void GameOverNextButton(){
		GameLevelValue = 1;
		LifeShowProblem = 1;
		OtherMenu [6].gameObject.SetActive (false);
		Ball.SaveScoresFirstLevel ();
		Application.LoadLevel (1);
		Play ();
	}
	public void WinMenu(){
		OtherMenu[5].gameObject.SetActive(true);
	}

	public void GoalPointLevel1(){
		OtherMenu [6].gameObject.SetActive (true);
	}
	///For Start Ball Running
	public int getStartBallRunValue(){
		return StartBallRun;
	}
	///For Life Problem
	public int getLifeShowProblemValue(){  //Life Recharge korbe nahhh ki life/life-- korbe
		return LifeShowProblem;
	}
	//For Game Level
	public int getGameLevelValue(){
		return GameLevelValue;
	}
	//Credit
	public void CreditImageScene(){
		OtherMenu [7].gameObject.SetActive (true);
		OtherMenu [2].gameObject.SetActive (false);
	}
}
