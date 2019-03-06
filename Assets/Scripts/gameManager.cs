using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gameManager : MonoBehaviour
{
    [SerializeField] private GameObject mainMenu;

    public static gameManager instance = null;
    private bool playerActive = false;
    private bool gameOver = false;
    private bool gameStarted = false;
    

    public bool PlayerActive
    {
        get { return playerActive; }
        
    }
    public bool GameOver
    {
        get { return gameOver; }
    }
    public bool GameStarted
    {
        get { return gameStarted; }
    }
    private void Awake()
        {
            if (instance == null)
            {
                instance = this;
            }
            else if (instance != this)
            {
                Destroy(gameObject);
            }            
            DontDestroyOnLoad(gameObject);                   
        }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayerCollider()
    {
        gameOver = true;
        
    }
    public void PlayerStartedGame()
    {
        playerActive = true;
    }
    public void EnterGame()
    {
        mainMenu.SetActive(false);
        gameStarted = true;
    }
}
