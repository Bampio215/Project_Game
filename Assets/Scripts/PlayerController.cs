using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public float horizontalInput;
    public float speed = 10.0f;
    private float xRange = 20;
    AudioManager audioManager;
    private Property playerProperty;

    public GameObject projectilePrefab;
    private bool delaySpace = false;

    Animator animator;

    void Start()
    {
        playerProperty = new Property();
        transform.rotation = Quaternion.Euler(0,0,0);
        animator = GetComponent<Animator>();
        animator.SetFloat("Speed_f",1);
        animator.SetBool("Static_b",true);
    }
    void Update()
    {
        
        transform.position = new Vector3(transform.position.x, 0, 0);
        if (transform.position.x < -xRange)
        {
            transform.position = new Vector3(-xRange, transform.position.y, transform.position.z);

        }
        if (transform.position.x > xRange)
        {
            transform.position = new Vector3(xRange, transform.position.y, transform.position.z);

        }

        if(Input.GetKey("a")){
            transform.rotation = Quaternion.Euler(0,-90,0);
            transform.Translate(Vector3.forward * Time.deltaTime * speed);
            animator.SetFloat("Speed_f",1);
            animator.SetBool("Static_b",false);
        }else if(Input.GetKey("d")){
            transform.rotation = Quaternion.Euler(0,90,0);
            transform.Translate(Vector3.forward * Time.deltaTime * speed);
            animator.SetFloat("Speed_f",1);
            animator.SetBool("Static_b",false);
        }else{
            transform.rotation = Quaternion.Euler(0,0,0);
            animator.SetBool("Static_b",true);
        }

        if (Input.GetKeyDown(KeyCode.Space) && !delaySpace)
        {
            audioManager.playSFX(audioManager.gunshot);

            Instantiate(projectilePrefab, transform.position, projectilePrefab.transform.rotation);
            delaySpace = true;
            transform.rotation = Quaternion.Euler(0,0,0);
            animator.SetBool("IsATK",true);
            StartCoroutine(Reset());

        }else{
            animator.SetBool("IsATK",false);
        }
        horizontalInput = Input.GetAxis("Horizontal");

        transform.Translate(Vector3.right * horizontalInput * Time.deltaTime * playerProperty.Speed);

    }
    IEnumerator Reset()
    {
        yield return new WaitForSeconds(0.5f);
        delaySpace = false;
    }
    private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }
}
