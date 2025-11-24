using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cloud : MonoBehaviour
{

    private float speed;

    private GameManager gameManager;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        transform.localScale = transform.localScale * Random.Range(0.1f, 0.6f);
        // Changed alpha to be more transparent
        transform.GetComponent<SpriteRenderer>().color = new Color(1.0f, 1.0f, 1.0f, Random.Range(0.1f, 0.5f));
        speed = Random.Range(3.0f, 7.0f) * gameManager.cloudMove;
    }

    // Update is called once per frame
    void Update()
    {
        
        transform.Translate(Vector3.down * speed * Time.deltaTime);

        if (transform.position.y < -gameManager.verticalScreenSize - 2.5f)
        {
            transform.position = new Vector3(Random.Range(-gameManager.horizontalScreenSize, gameManager.horizontalScreenSize), gameManager.verticalScreenSize * 1.2f, 0);
        }

    }
}