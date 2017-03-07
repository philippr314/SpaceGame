using UnityEngine;
using System.Collections;

public class UserInput : MonoBehaviour {

	SpacecraftControl spacecraftControl;

	void Start () 
	{
		spacecraftControl = GetComponent<SpacecraftControl> ();
	}
	

	void FixedUpdate () 
	{
		float roll = Input.GetAxis("Horizontal");
		float pitch = Input.GetAxis("Vertical");
		bool airBrakes = Input.GetButton("Fire1");
		float throttle = Input.GetAxis ("Throttle");

		spacecraftControl.Move (roll, pitch, 0, throttle, airBrakes);
	}
}
