using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield : MonoBehaviour
{
    private GameManager gameManager;
    private PlayerController playerController;
    private GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        playerController = GameObject.Find("Player").GetComponent<PlayerController>();
        player = GameObject.Find("Player");
    }
    // Update is called once per frame
    void Update()
    {
        transform.position = player.transform.position;
    }
}