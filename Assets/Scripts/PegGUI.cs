using UnityEngine;
using System.Collections;

public class PegGUI : MonoBehaviour {

	public static int counter = 0;
	private const float INIT_TIMER = 30.0f; //Max time for gameplay
	private float timer = INIT_TIMER;
	public GUIStyle style;
	public GameObject peg01;
	public GameObject peg02;
	public GameObject peg03;
	public GameObject peg04;
	public GameObject peg05;
	public GameObject peg06;
	public Light light;

	void Update(){
		if (timer > 0) {
			timer -= Time.deltaTime;
		} else {
			timer = 0;
		}
	}

	void OnGUI(){

		//Make timer and score strings
		string sTimer = timer.ToString();
		string sCounter = "Score: " + counter.ToString ();

		//Create labels
		GUI.Label (new Rect(0, 0, 100, 80), sTimer, style);
		GUI.Label (new Rect(Screen.width - 200, 0, 200, 80), sCounter, style);

		//When game ends
		if (timer == 0){
			//Make pegs and light inactive
			togglePeg(false);

			//Create reset button
			if(GUI.Button (new Rect(Screen.width - 100, Screen.height - 50, 100, 50), "Reset", style)){
				//Re-initialize variables
				counter = 0;
				timer = INIT_TIMER;
				togglePeg(true);
			}
		}
	}

	//Make pegs and light active or inactive
	void togglePeg(bool tog){
		peg01.SetActive (tog);
		peg02.SetActive (tog);
		peg03.SetActive (tog);
		peg04.SetActive (tog);
		peg05.SetActive (tog);
		peg06.SetActive (tog);
		light.enabled = tog;
	}
}
