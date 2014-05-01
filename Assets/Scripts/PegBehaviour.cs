using UnityEngine;
using System.Collections;

public class PegBehaviour : MonoBehaviour {

	private const float LERPSPEED = 5.0f; //Speed of peg
	private float timeRise;
	private float timeDesc;
	private float timeReset;
	private Vector3 newPosition;
	private Vector3 positionA;
	private Vector3 positionB;
	private float timeCounter;

	// Use this for initialization
	void Start () {
		//Set postions
		newPosition = transform.position;
		positionA = newPosition;
		positionB = newPosition;
		positionB.y += 2.5f; //Set above positionA

		timeRise = 1.0f; //Time until peg rises
		setRand ();

		timeCounter = 0;
	}
	
	void Update () {

		if (timeCounter < timeRise) {
			newPosition = positionB;
			//Move peg upwards
			transform.position = Vector3.Lerp(transform.position, newPosition, LERPSPEED * Time.deltaTime);

		}

		if (timeCounter > timeDesc) {
			newPosition = positionA;
			//Move peg downwards
			transform.position = Vector3.Lerp(transform.position, newPosition, LERPSPEED * Time.deltaTime);
		}

		if (timeCounter > timeReset) {
			//Reset timer
			timeCounter = 0;
		}

		//Update timer
		timeCounter += Time.deltaTime;
	}

	void OnMouseDown(){
		resetPop ();
		setRand ();
		timeCounter = 3;
		PegGUI.counter += 1;
	}

	//Send peg straight into downwards positionA
	void resetPop(){
		newPosition = positionA;
		transform.position = newPosition;
	}

	//Set random variables for time intervals
	void setRand(){
		timeDesc = 1.0f + 2*Random.value;
		timeReset = 3.0f + 3*Random.value;
	}
}
