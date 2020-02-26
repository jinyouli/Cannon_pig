using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bomb : MonoBehaviour {
	public GameObject boom;
	int count_down = 3;
    private Rigidbody2D rb;
	bool m_oneTime = true;

	public LayerMask layerMask;

	Collider[] collidedObj;

	void Start () {
		rb = GetComponent<Rigidbody2D>();
		InvokeRepeating ("Time_count", 2.0f, 1.0F);
		ChangeImage("bomb");
	}

	void FixedUpdate () {
		if (m_oneTime)
        {
			Vector3 mouse = Input.mousePosition;
			Vector2 force = new Vector2(mouse.x,mouse.y);
			rb.AddForce(force * 0.7f,ForceMode2D.Force); 
			m_oneTime = false;
		}
	}

	void Time_count()
	{  
		if (count_down > 0) {
			count_down--;
			ChangeImage("bomb_" + count_down);

		} else {
			CancelInvoke ();

			Destroy(gameObject);
            Instantiate(boom, transform.position, Quaternion.identity);

			Collider2D[] colliders = Physics2D.OverlapCircleAll(this.transform.position,10.0f,layerMask);
			for(int i = 0; i < colliders.Length; i++){
				if(colliders[i].gameObject.tag == "Pig"){
					GameManager._instance.ReducePig(colliders[i].gameObject.name);
				}
			}	
		}
	}

	void ChangeImage(string path){
		SpriteRenderer spr = gameObject.GetComponent<SpriteRenderer>();
		Texture2D texture2d = (Texture2D)Resources.Load(path);
		Sprite sp = Sprite.Create(texture2d,spr.sprite.textureRect,new Vector2(0.37f,0.37f));
		spr.sprite = sp;
	}

	private void OnCollisionEnter2D(Collision2D collision)
    {
        switch (collision.gameObject.tag)
        {
            case "Enemy":

                break;
            default:
                break;
        }
    }
}
