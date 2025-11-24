using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Merging code from PlayerController into Player
    public int lives;
    private GameManager gameManager;
    private float playerSpeed;
    private int weaponType;

    private float horizontalInput;
    private float verticalInput;

    private float horizontalScreenLimit = 8.5f;
    // Restrictions on vertical space made this useless in this script
    //private float verticalScreenLimit = 3.5f;

    public GameObject bulletPrefab;
    public GameObject explosionPrefab;

    public GameObject thrusterPrefab;
    public GameObject shieldPrefab;

    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        lives = 3;
        playerSpeed = 6.0f;
        gameManager.ChangeLivesText(lives);

    }

    void Update()
    {
        //This function (update) is called every frame; 60 frames/second
        Movement();
        Shooting();

    }

    public void LoseALife()
    {
        // Is there shield? FIXME
        // Yes: dont lose life; deativate shield
        // No: lose a life
        lives--;
        Debug.Log("Player hit! Lose a life.");
        gameManager.ChangeLivesText(lives);
        if (lives == 0)
        {
            Instantiate(explosionPrefab, transform.position, Quaternion.identity);
            Destroy(this.gameObject);
            gameManager.GameOver();
        }
    }

    // Slowing Down
    IEnumerator SpeedPowerDown()
    {
        yield return new WaitForSeconds(3.0f);
        playerSpeed = 5.0f;
        thrusterPrefab.SetActive(false);
        gameManager.ManagePowerupText(0);
        gameManager.PlaySound(2);
    }

    // Weapons powering down
    IEnumerator WeaponPowerDown()
    {
        yield return new WaitForSeconds(3.0f);
        weaponType = 1;
        gameManager.ManagePowerupText(0);
        gameManager.PlaySound(2);
    }

    private void OnTriggerEnter2D(Collider2D whatDidIHit)
    {
        if (whatDidIHit.tag == "Powerup")
        {
            Debug.Log("Power Up Hit!");
            gameManager.PlaySound(1);
            Destroy(whatDidIHit.gameObject);
            Instantiate(shieldPrefab, transform.position, Quaternion.identity);
            /* Cant get power up switch cases to work
            int whichPowerup = Random.Range(1, 4);
            switch (whichPowerup)
            {
                case 1:
                    //Picked up speed
                    playerSpeed = 10.0f;
                    StartCoroutine(SpeedPowerDown());
                    thrusterPrefab.SetActive(true);
                    gameManager.ManagePowerupText(1);
                    break;
                case 2:
                    weaponType = 2; //Picked up double weapon
                    StartCoroutine(WeaponPowerDown());
                    gameManager.ManagePowerupText(2);
                    break;
                case 3:
                    weaponType = 3; //Picked up triple weapon
                    StartCoroutine(WeaponPowerDown());
                    gameManager.ManagePowerupText(3);
                    break;
                case 4:
                    //Picked up shield
                    //Do I already have a shield? FIXME
                    //If yes: do nothing
                    //If not: activate the shield's visibility
                    gameManager.ManagePowerupText(4);
                    break;
            }*/
        }
    }

    void Shooting()
    {
        //if the player presses the SPACE key, create a projectile
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(bulletPrefab, transform.position + new Vector3(0, 0.5f, 0), Quaternion.identity);
            /*
            switch (weaponType)
            {
                case 1:
                    Instantiate(bulletPrefab, transform.position + new Vector3(0, 0.5f, 0), Quaternion.identity);
                    break;
                case 2:
                    Instantiate(bulletPrefab, transform.position + new Vector3(-0.5f, 0.5f, 0), Quaternion.identity);
                    Instantiate(bulletPrefab, transform.position + new Vector3(0.5f, 0.5f, 0), Quaternion.identity);
                    break;
                case 3:
                    Instantiate(bulletPrefab, transform.position + new Vector3(-0.5f, 0.5f, 0), Quaternion.Euler(0, 0, 45));
                    Instantiate(bulletPrefab, transform.position + new Vector3(0, 0.5f, 0), Quaternion.identity);
                    Instantiate(bulletPrefab, transform.position + new Vector3(0.5f, 0.5f, 0), Quaternion.Euler(0, 0, -45));
                    break;
            }*/
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
        }
        else if (transform.position.y < -3.5f)
        {
            transform.position = new Vector3(transform.position.x, 0, 0);
        }
    }

}