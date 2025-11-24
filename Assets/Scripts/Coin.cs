using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    // public GameObject explosionPrefab;
    private GameManager gameManager;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        // Changed final parameter negative to make enemies travel downwards
        transform.Translate(new Vector3(0, -1, 0) * Time.deltaTime * 3f);
        if (transform.position.y < -4f)
        {
            Destroy(this.gameObject);
        }
    }

    // Collect the money
    private void OnTriggerEnter2D(Collider2D whatDidIHit)
    {
        if (whatDidIHit.gameObject.tag == "Player" || whatDidIHit.gameObject.tag == "Weapons")
        {
            //Instantiate(explosionPrefab, transform.position, Quaternion.identity);
            Destroy(this.gameObject);
            gameManager.AddScore(5);
        }
    }
}