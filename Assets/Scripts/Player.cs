using System.Collections;
using System.Collections.Generic;
using UnityEngine.Assertions;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float jumpForce = 8.5f;
    [SerializeField] private AudioClip sfxJump;
    [SerializeField] private AudioClip sfxDeath;

    private Animator anim;
    private Rigidbody rigidBody;
    private AudioSource audioSource;
    private bool jump;


    private void Awake()
    {
        Assert.IsNotNull(sfxJump);
        Assert.IsNotNull(sfxDeath);
    }

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        rigidBody = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();

    }

    // Update is called once per frame
    void Update()
    {
        if (!gameManager.instance.GameOver && gameManager.instance.GameStarted)
        {
            if (Input.GetMouseButtonDown(0))
            {
                gameManager.instance.PlayerStartedGame();
                anim.Play("Jump");
                audioSource.PlayOneShot(sfxJump);
                rigidBody.useGravity = true;
                jump = true;
            }
        }
        if (transform.localPosition.y > 5.5f || transform.localPosition.y < -5.21f)
        {
            Death();
        }
    }

    private void FixedUpdate()
    {
        if (jump == true)
        {
            jump = false;
            rigidBody.velocity = new Vector2(0, 0);
            rigidBody.AddForce(new Vector2(0, jumpForce), ForceMode.Impulse);
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "obstacle")
        {
            Death();
        }
    }
    private void Death()
    {
        rigidBody.AddForce(new Vector2(3, 0), ForceMode.Impulse);
        rigidBody.detectCollisions = false;
        audioSource.PlayOneShot(sfxDeath);
        gameManager.instance.PlayerCollider();
    }
}
