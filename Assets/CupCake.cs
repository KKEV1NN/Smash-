using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CupCake : MonoBehaviour
{
	public int minforce;

	private void OnCollisionEnter(Collision col)
	{
		print("The Magnitude Cupcake Was " + col.relativeVelocity.magnitude.ToString());
		if (col.relativeVelocity.magnitude >= minforce)
		{
			Debug.Log("Quitting");
			Application.Quit();
		}
	}
}
