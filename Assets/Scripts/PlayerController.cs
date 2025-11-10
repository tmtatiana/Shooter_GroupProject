using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Merging code from PlayerController into Player
    public int lives;
    private GameManager gameManager;

    private float playerSpeed;
    private float horizontalInput;
    private float verticalInput;

    private float horizontalScreenLimit = 8.5f;
    // Restrictions on vertical space made this useless in this script
    //private float verticalScreenLimit = 3.5f;

    public GameObject bulletPrefab;
    public GameObject explosionPrefab;

    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        lives = 3;
        playerSpeed = 6.0f;
        gameManager.ChangeLivesText(lives);

    }

    void Update()
    {
        //This function is called every frame; 60 frames/second
        Movement();
        Shooting();

    }

    public void LoseALife()
    {
        // lives -= 1;
        lives--;
        Debug.Log("Player hit! Lose a life.");
        gameManager.ChangeLivesText(lives);
        if (lives == 0)
        {
            Instantiate(explosionPrefab, transform.position, Quaternion.identity);
            Destroy(this.gameObject);
        }
    }

    void Shooting()
    {
        //if the player presses the SPACE key, create a projectile
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(bulletPrefab, transform.position + new Vector3(0, 0.5f, 0), Quaternion.identity);
        }
    }

    void Movement()
    {
        //Read the input from the player
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");
        //Move the player
        transform.Translate(new Vector3(horizontalInput, verticalInput, 0) * Time.deltaTime * playerSpeed);
        //Player leaves the screen horizontally
        if (transform.position.x > horizontalScreenLimit || transform.position.x <= -horizontalScreenLimit)
        {
            transform.position = new Vector3(transform.position.x * -1, transform.position.y, 0);
        }
        //Player leaves the screen vertically (only occupies lower half of the screen)
            //script from class:
            //    if (transform.position.y > verticalScreenLimit || transform.position.y <= -verticalScreenLimit)
            //    {
            //            transform.position = new Vector3(transform.position.x, transform.position.y * -1, 0);
            //    }
        if (transform.position.y >= 0)
        {
            transform.position = new Vector3(transform.position.x, -3.5f, 0);
        } else if (transform.position.y < -3.5f)
        {
            transform.position = new Vector3(transform.position.x, 0, 0);
        }
    }

}