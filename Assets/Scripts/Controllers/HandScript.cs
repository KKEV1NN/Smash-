using System.Collections;
using System.Collections.Generic;
using Valve.VR;
using UnityEngine;

public class HandScript : MonoBehaviour
{

	public SteamVR_Input_Sources thisHand;
	public SteamVR_Action_Boolean trigger;
	public SteamVR_Action_Boolean grip;
	public SteamVR_Behaviour_Pose controller;


	public GameObject curheldObj; 

	FixedJoint m_joint;

	bool isHolding;

    // Start is called before the first frame update
    void Start()
    {

		m_joint = GetComponent<FixedJoint>();

    }

    // Update is called once per frame
    void Update()
    {

		if (trigger.GetLastStateUp(thisHand))
		{
			Drop();
		}
		if (trigger.GetStateDown(thisHand))
		{
			
			Grab();
		}
        
    }

	private void OnTriggerEnter(Collider other)
	{
		if (!isHolding)
		{
			if (other.gameObject.CompareTag("Interactable"))
			{
				curheldObj = other.gameObject;

			}
		}
	}

	private void OnTriggerExit(Collider other)
	{
		if (!isHolding)
		{
			if (other.gameObject.CompareTag("Interactable"))
			{
				curheldObj = null;
			}
		}
	}

	void Grab()
	{

		if(curheldObj != null)
		{
			isHolding = true;
			m_joint.connectedBody = curheldObj.GetComponent<Rigidbody>();
		}

	}

	void Drop()
	{
		if (m_joint.connectedBody !=null)
		{

			curheldObj.GetComponent<Rigidbody>().velocity = controller.GetVelocity();
			curheldObj.GetComponent<Rigidbody>().angularVelocity = controller.GetAngularVelocity();
			isHolding = false;
			m_joint.connectedBody = null;

		}

	}
}
