using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

    public List<Bird> birds;
    public List<Pig> pig;
    public List<Pig> woods;
    public static GameManager _instance;
    private Vector3 originPos; //初始化的位置

    public GameObject win;
    public GameObject lose;

    public GameObject[] stars;

    private int starsNum = 0;

    private int totalNum = 9;

    private void Awake()
    {
        _instance = this;
        if(birds.Count > 0) {
            originPos = birds[0].transform.position;
        }
    }

    private void Start()
    {
        Initialized();
       // PlayerPrefs.SetInt("totalNum",8);
    }

    /// <summary>
    /// 初始化小鸟
    /// </summary>
    private void Initialized()
    {
        for(int i = 0; i < birds.Count; i++)
        {
            if (i == 0) //第一只小鸟
            {
                birds[i].transform.position = originPos;
                birds[i].enabled = true;
                birds[i].sp.enabled = true;

            }
            else
            {
                birds[i].enabled = false;
                birds[i].sp.enabled = false;
            }
        }
    }

    /// <summary>
    /// 判定游戏逻辑
    /// </summary>
   public void NextBird()
    {
        if(pig.Count <= 0)
        {
            //lose.SetActive(true);
            win.SetActive(true);
        }
    }

    public void ShowStars() {
        StartCoroutine("show");
    }

    IEnumerator show() {
        for (; starsNum < stars.Length; starsNum++)
        {
            yield return new WaitForSeconds(0.2f);
            stars[starsNum].SetActive(true);
        }
    }

    public void Replay() {
        SaveData();
        SceneManager.LoadScene(2);
    }

    public void ReducePig(string pigname){

        for(int i=0; i<pig.Count;i++){
            Pig currentpig = pig[i];
            if(currentpig.name == pigname){
                currentpig.PigDead();
            }
        }

        for(int i=0; i<woods.Count;i++){
            Pig currentpig = woods[i];
            if(currentpig.name == pigname){
                currentpig.PigDead();
            }
        }
    }

    public void Home() {
        SaveData();
        SceneManager.LoadScene(1);
    }

    public void SaveData() {
        PlayerPrefs.SetInt(PlayerPrefs.GetString("nowLevel"), stars.Length);
        int sum = 0;        
        for (int i = 1; i <= totalNum; i++) {
            sum += PlayerPrefs.GetInt("level" + i.ToString());
        }
        PlayerPrefs.SetInt("totalNum",sum);
    }
}


