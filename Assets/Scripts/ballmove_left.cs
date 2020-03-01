using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ballmove_left : MonoBehaviour {
	public float speed = 6;
	public float start_point;
	public float end_point;
	void Update()
	{
		transform.position += Vector3.right * speed * Time.deltaTime;
		if (transform.position.x>=start_point || transform.position.x <= end_point)
		{
			speed = -speed;
		}
	}
}
