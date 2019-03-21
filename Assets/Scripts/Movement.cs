using System.Collections;
using System.Collections.Generic;
using Valve.VR; 
using UnityEngine;

public class Movement : MonoBehaviour
{
	public SteamVR_Input_Sources _Hand;
	public SteamVR_Action_Vector2 _Touchpad;
	public float speed; 
	public Camera InsertCamHere; 

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
		var yAxis = _Touchpad.GetAxis(_Hand).y;
		var xAxis = _Touchpad.GetAxis(_Hand).x;

		transform.position += (InsertCamHere.transform.right * xAxis * speed + InsertCamHere.transform.forward * yAxis * speed) * Time.deltaTime;
		transform.position = new Vector3(transform.position.x, 0, transform.position.z);
    }
}
