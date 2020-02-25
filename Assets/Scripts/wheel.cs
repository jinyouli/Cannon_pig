using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wheel : MonoBehaviour {
 	public float angle = 179f;

	// Use this for initialization
	void Start () {
		transform.localEulerAngles = new Vector3(transform.localEulerAngles.x,transform.localEulerAngles.y,180f);
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		Vector3 dis = Camera.main.ScreenToWorldPoint(Input.mousePosition); 
		dis.z = this.transform.position.z; 
		this.transform.position = dis; 

		this.transform.position= Vector3.Lerp(this.transform.position,dis,Time.deltaTime);
		this.transform.position = Vector3.MoveTowards(this.transform.position, dis, Time.deltaTime);
		Vector3 speed = Vector3.zero;
		this.transform.position = Vector3.SmoothDamp(this.transform.position, dis,ref speed, 0.1f);

		if (Input.GetMouseButton(0))
        {
			transform.localEulerAngles = new Vector3(transform.localEulerAngles.x,transform.localEulerAngles.y,0);
		}

		if(transform.eulerAngles.z <= angle)
		{
			transform.Rotate(0, 0, 200 *Time.deltaTime, Space.World);
		}
	}
}
