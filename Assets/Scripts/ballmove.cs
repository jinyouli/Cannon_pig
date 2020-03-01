using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ballmove : MonoBehaviour {

	public float speed = 6;
	public float start_point = 2.0f;
	public float end_point = -3.48f;
	void Update()
	{
		transform.position += Vector3.up * speed * Time.deltaTime;
		if (transform.position.y>=start_point || transform.position.y <= end_point)
		{
			speed = -speed;
		}
	}
}
