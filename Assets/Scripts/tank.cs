using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tank : MonoBehaviour {

	private Vector3 bullectEulerAngles;
    private float timeVal;
	public RectTransform uGUICanvas;
    public float rotateSpeed = 0.5f;
	public GameObject bullectPrefab;
	private Vector3 direction;

    void FixedUpdate () {
        Vector3 mouse = Input.mousePosition;
        //获取物体坐标，物体坐标是世界坐标，将其转换成屏幕坐标，和鼠标一直  
        Vector3 obj = Camera.main.WorldToScreenPoint(transform.position);
        //屏幕坐标向量相减，得到指向鼠标点的目标向量，即黄色线段  
        direction = mouse - obj;
        //将Z轴置0,保持在2D平面内   
        direction.z = 0f;
        //将目标向量长度变成1，即单位向量，这里的目的是只使用向量的方向，不需要长度，所以变成1  
        direction = direction.normalized;
		if(direction.x < 0){
			direction.x = 0;
		}
		
		if(direction.y + 0.3f > 0){
            //物体自身的Y轴和目标向量保持一直，这个过程XY轴都会变化数值  
			transform.up = direction;
		}

		if (timeVal >= 0.4f)
        {
            Attack();
        }
        else
        {
            timeVal += Time.fixedDeltaTime;
        }

        bullectEulerAngles = new Vector3(0, 0, 0);
    }

	private void Attack()
    {
        if (Input.GetMouseButton(0))
        {
            Instantiate(bullectPrefab, transform.position + direction * 2.5f,Quaternion.Euler(transform.eulerAngles+bullectEulerAngles));
            timeVal = 0;
        }
    }
}
