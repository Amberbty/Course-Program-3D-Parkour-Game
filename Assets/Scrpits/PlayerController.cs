using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    private Rigidbody playerRb;
    private Animator playerAnim;
    public float moveSpeed;
    public float horizontalInput;
    public float gravityModifier;
    public float jumpForce;
    public bool isOnGround;
    public bool gameOver;
    public ParticleSystem boom;
    public ParticleSystem dirt;
    public AudioClip jumpSound;
    public AudioClip crashSound;
    private AudioSource playerAudio;
    private AudioSource stepAudio;
    public bool hasPowerup;
    public GameObject powerupIndicator;
    private GameManager gameManager;


    // Start is called before the first frame update
    void Start()
    {
        gameOver = false;
        isOnGround = true;
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
        playerRb = GetComponent<Rigidbody>();
        playerAnim = GetComponent<Animator>();
        Physics.gravity = Vector3.down * 9.81f * gravityModifier;
        playerAudio = GetComponent<AudioSource>();
        stepAudio = GameObject.Find("Step Sound").GetComponent<AudioSource>();
        Debug.Log("Gravity Modifier is: " + gravityModifier);
        Debug.Log("Jump Force is: " + jumpForce);

        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //Move left and right
        if(!gameOver)
        {
            horizontalInput = Input.GetAxis("Horizontal");
            transform.Translate(Vector3.right * Time.deltaTime * moveSpeed * horizontalInput);
        }

        //Fix the position
        if(transform.position.x > 6)
        {
            transform.position = new Vector3(6,transform.position.y, transform.position.z);
        }
        else if (transform.position.x < -6)
        {
            transform.position = new Vector3(-6, transform.position.y, transform.position.z);
        }

        //Make player jump
        if(Input.GetKeyDown(KeyCode.Space) && isOnGround && !gameOver)
        {
            playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isOnGround =false;
            playerAnim.SetTrigger("Jump_trig");
            playerAudio.PlayOneShot(jumpSound, 0.5f); //1.0f is volume
            dirt.Stop();
            stepAudio.mute = true;
            Debug.Log("Pressed Jump Button");
        }

        powerupIndicator.transform.position = transform.position + new Vector3(0, 1.82f, 0.2f);

    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Ground") &&!gameOver)
        {
            isOnGround = true;
            dirt.Play();
            stepAudio.mute = false;
        }
        else if(collision.gameObject.CompareTag("Obstacle"))
        {
            gameOver = true;
            isOnGround = true;
            Debug.Log("Game Over!");
            playerAnim.SetBool("Death_b", true);
            playerAnim.SetInteger("DeathType_int", 1);
            boom.Play();
            playerAudio.PlayOneShot(crashSound, 0.5f);
            dirt.Stop();
            stepAudio.mute = true;
            gameManager.GameOver();
            
        }

        if(collision.gameObject.CompareTag("Obstacle") && hasPowerup)
        {
            Debug.Log("Collided with " + collision.gameObject.name);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Powerup"))
        {
            hasPowerup = true;
            Destroy(other.gameObject);
            jumpForce = 240;
            powerupIndicator.gameObject.SetActive(true);
            StartCoroutine(PowerupCountdownRoutine());
        }
    }

    IEnumerator PowerupCountdownRoutine()
    {
        yield return new WaitForSeconds(5);
        hasPowerup = false;
        powerupIndicator.gameObject.SetActive(false);
        jumpForce = 140;
    }
}
