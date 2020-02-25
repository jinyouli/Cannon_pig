using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pig : MonoBehaviour {

    public float maxSpeed = 10;
    public float minSpeed = 5;
    public Sprite hurt;
    public GameObject boom;
    public GameObject score;

    public AudioClip hurtClip;
    public AudioClip dead;
    public AudioClip birdCollision;

    public bool isPig = false;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player" && gameObject.tag == "Pig") {
           AudioPlay(birdCollision);
           // collision.transform.GetComponent<Bird>().Hurt();
           //Dead();
        }

        if (collision.relativeVelocity.magnitude > maxSpeed)//直接死亡
        {
           // Dead();
        } else if (collision.relativeVelocity.magnitude > minSpeed && collision.relativeVelocity.magnitude < maxSpeed) {
            AudioPlay(hurtClip);
        }
    }
    
    public void PigDead() {
        if (isPig)
        {
            GameManager._instance.pig.Remove(this);
            GameManager._instance.NextBird();
        }
        
        Destroy(gameObject);
        Instantiate(boom, transform.position, Quaternion.identity);
        GameObject go = Instantiate(score, transform.position + new Vector3(0,0.5f,0), Quaternion.identity);
        Destroy(go, 1.5f);
        AudioPlay(dead);
    }

    public void AudioPlay(AudioClip clip)
    {
        AudioSource.PlayClipAtPoint(clip, transform.position);
    }

}
