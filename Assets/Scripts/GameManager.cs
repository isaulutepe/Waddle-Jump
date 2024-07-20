using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SocialPlatforms.Impl;

public class GameManager : MonoBehaviour
{
    PlayeerController playerController;
    public TextMeshProUGUI text;
    public TextMeshProUGUI highScoreeText;
    private int counter;
    public float timer = 10f;
    SpawnerScript spawner;
    RoadScript[] left; //Ýki tane yol var
    RoadScript2[] right;
    int currentScore = 0;
    int hightScore;

    TweeningScript tweeningScript;


    private void Start()
    {
        playerController = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayeerController>();
        spawner = GameObject.FindGameObjectWithTag("spawner").GetComponent<SpawnerScript>();
        tweeningScript= GameObject.FindGameObjectWithTag("gameManager").GetComponent<TweeningScript>();


        GameObject parentRoad = GameObject.FindGameObjectWithTag("road");

        List<RoadScript> leftList = new List<RoadScript>();
        List<RoadScript2> rightList = new List<RoadScript2>();

        foreach (Transform child in parentRoad.transform)
        {
            if (child.CompareTag("left"))
            {
                RoadScript leftRoad = child.GetComponent<RoadScript>();
                if (leftRoad != null)
                {
                    leftList.Add(leftRoad);
                }
            }
            if (child.CompareTag("right"))
            {
                RoadScript2 rightRoad = child.GetComponent<RoadScript2>();
                if (rightRoad != null)
                {
                    rightList.Add(rightRoad);
                }
            }
        }

        //Listeyi diziye çevirelim
        left = leftList.ToArray();
        right = rightList.ToArray();

        if (playerController.isDie == false)
        {
            StartCoroutine(WaitAnimation());
        }

        //Yüksek scoru görüntüle
        highScoreeText.text = LoadHighScore().ToString(); 
    }

    public void isDie()
    {
        UpdateHighScore(currentScore);
        tweeningScript.OpenPanel();
        this.gameObject.SetActive(false);
        playerController.gameObject.SetActive(false);
    }
    private void Update()
    {
        if (playerController != null)
        {
            if (playerController.isDie)
            {

                isDie();
             
            }
            else
            {
                switch (counter)
                {
                    case 10:
                        //Hýz artacak
                        AddDifficulty(2, 6, 4, 4);
                        Debug.Log("10");
                        break;
                    case 20:
                        AddDifficulty(6, 8, 3, 6);
                        Debug.Log("20");
                        break;
                    case 30:
                        AddDifficulty(8, 12, 3, 8);
                        break;
                    case 40:
                        AddDifficulty(9, 14, 2, 10);
                        break;
                }
                if (counter > 50)
                {
                    AddDifficulty(11, 15, 1, 12);
                }
            }
        }
    }


    void SaveHighScore(int newHighScore)
    {
        PlayerPrefs.SetInt("HighScore", newHighScore);
        PlayerPrefs.Save();
    }
    int LoadHighScore()
    {
        return PlayerPrefs.GetInt("HighScore",0);
    }
    void UpdateHighScore(int currentScore)
    {
        if (currentScore > LoadHighScore())
        {
            SaveHighScore(currentScore);
        }
    }




    public void AddDifficulty(int a, int b, int c, int d) //a-b random number, c create time, d Roadspeed,
    {
        //Hýz artacak
        spawner.upForceRight = Random.Range(a, b);
        spawner.upForceLeft = Random.Range(a + 2, b + 3);
        spawner.createTime = c;
        for (int i = 0; i < left.Length; i++)
        {
            left[i].speed = d;
        }
        for (int i = 0; i < right.Length; i++)
        {
            right[i].speed = d;
        }
    }
    IEnumerator AddScore()
    {
        while (true)
        {
            counter += 1;
            currentScore = counter;
            yield return new WaitForSeconds(timer);
            text.text = currentScore.ToString();
        }
    }
    IEnumerator WaitAnimation()
    {
        yield return new WaitForSeconds(2f);
        StartCoroutine(AddScore());
    }
}
