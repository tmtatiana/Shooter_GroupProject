using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{

    public GameObject playerPrefab;
    public GameObject enemyOnePrefab;
    public GameObject enemyTwoPrefab;
    public GameObject cloudPrefab;

    // Unsure of this functionality but it was present in canvas scripts
    // public TextMeshProUGUI livesText;

    public float horizontalScreenSize;
    public float verticalScreenSize;

    public int score;

    // Start is called before the first frame update
    void Start()
    {
        horizontalScreenSize = 8.5f;
        verticalScreenSize = 3.5f;
        score = 0;
        //Instantiate(playerPrefab, transform.position, Quaternion.identity);
        CreateSky();
        InvokeRepeating("CreateEnemy", 2, 3);
        InvokeRepeating("CreateEnemy2", 1, 2);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void CreateEnemy()
    {
        Instantiate(enemyOnePrefab, new Vector3(Random.Range(-horizontalScreenSize, horizontalScreenSize) * 0.9f, verticalScreenSize, 0), Quaternion.Euler(180, 0, 0));
    }

    void CreateEnemy2()
    {
        Instantiate(enemyTwoPrefab, new Vector3(Random.Range(-2, horizontalScreenSize), verticalScreenSize, 0), Quaternion.Euler(180, 0, 0));
    }

    void CreateSky()
    {
        for (int i = 0; i < 30; i++)
        {
            Instantiate(cloudPrefab, new Vector3(Random.Range(0, horizontalScreenSize), Random.Range(-verticalScreenSize, verticalScreenSize), 0), Quaternion.identity);
        }

    }
    public void AddScore(int pointsAdded)
    {
        score += pointsAdded;
        Debug.Log("Score: " + score);
    }

    public void ChangeLivesText(int currentLives)
    {
        //livesText.text = "Lives: " + currentLives;
        Debug.Log("Lives: " + currentLives);
    }
}


/* Original GameManager
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public GameObject enemyOnePrefab;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("CreateEnemyOne", 1, 2);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void CreateEnemyOne()
    {
        Instantiate(enemyOnePrefab, new Vector3(Random.Range(-9f, 9f), 6.5f, 0), Quaternion.identity);
    }
}
*/
