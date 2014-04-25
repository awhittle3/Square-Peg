using UnityEngine;
using System.Collections;

public class PegBehaviour : MonoBehaviour {

	private const float LERPSPEED = 5.0f;
	private float timeRise;
	private float timeDesc;
	private float timeReset;
	private Vector3 newPosition;
	private Vector3 positionA;
	private Vector3 positionB;
	private float timeCounter;

	// Use this for initialization
	void Start () {
		newPosition = transform.position;
		positionA = newPosition;
		positionB = newPosition;
		positionB.y += 2.5f;

		timeRise = 1.0f;
		setRand ();

		timeCounter = 0;
	}
	
	void Update () {

		if (timeCounter < timeRise) {
			newPosition = positionB;
			transform.position = Vector3.Lerp(transform.position, newPosition, LERPSPEED * Time.deltaTime);

		}

		if (timeCounter > timeDesc) {
			newPosition = positionA;
			transform.position = Vector3.Lerp(transform.position, newPosition, LERPSPEED * Time.deltaTime);
		}

		if (timeCounter > timeReset) {
			timeCounter = 0;
		}

		timeCounter += Time.deltaTime;
	}

	void OnMouseDown(){
		resetPop ();
		setRand ();
		timeCounter = 3;
		PegGUI.counter += 1;
	}

	void resetPop(){
		newPosition = positionA;
		transform.position = newPosition;
	}

	void setRand(){
		timeDesc = 1.0f + 2*Random.value;
		timeReset = 3.0f + 3 * Random.value;
	}
}
