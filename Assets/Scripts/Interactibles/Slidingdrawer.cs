using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slidingdrawer : MonoBehaviour
{

	Transform parent;
	public Transform pointA;
	public Transform pointB;

	Vector3 offset;
	
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (parent != null)
		{
			transform.position = ClosetPointOnLine(parent.position) - offset;
		}
    }

	public void PickUp()
	{
		offset = parent.position - transform.position;
	}

	public void Drop()
	{
		
	}

	Vector3 ClosetPointOnLine (Vector3 point)
	{
		Vector3 va = pointA.position + offset;
		Vector3 vb = pointB.position + offset;

		Vector3 vVector1 = point - va;

		Vector3 vVector2 = (vb - va).normalized;
		//The dot product is a float value equal to the magnitudes of the two vectors multiplied together and then multiplied by the cosine of the angle between them.
		float t = Vector3.Dot(vVector2, vVector1); 

		if(t <= 0)
		{
			return va;
		}

		if(t >= Vector3.Distance(va, vb))
		{
			return vb;
		}

		Vector3 vVector3 = vVector2 * t;

		Vector3 vClosestPoint = va + vVector3;

		return vClosestPoint; 
	}
}
