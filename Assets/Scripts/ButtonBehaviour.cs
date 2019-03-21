using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonBehaviour : MonoBehaviour
{
	Rigidbody rb;
	public float forceMultipiler = 1f;
	public GameObject currentDoor; 

    // Start is called before the first frame update
    void Start()
    {
		rb = GetComponent<Rigidbody>();
		
	}

    // Update is called once per frame
    void Update()
    {
		rb.AddForce(transform.up * forceMultipiler);
    }

	private void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.CompareTag("ButtonTarget"))
		{
			currentDoor.GetComponent<MeshCollider>().convex = false; 
			Debug.Log("Click");
		}
	}

	//private void OnCollisionEnter(Collision collision)
	//{
	//	Debug.Log(collision.gameObject.name);
	//	if (collision.gameObject.CompareTag("ButtonTarget"))
	//	{
	//		Debug.Log("CLICK");
	//	}

	//}
}
