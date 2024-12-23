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

    // Start is called before the first frame update
    void Start()
    {
        playerProperty = new Property();
    }
    
    // Update is called once per frame
    void Update()
    {
        if (transform.position.x < -xRange)
        {
            transform.position = new Vector3(-xRange, transform.position.y, transform.position.z);

        }
        if (transform.position.x > xRange)
        {
            transform.position = new Vector3(xRange, transform.position.y, transform.position.z);

        }
        if (Input.GetKeyDown(KeyCode.Space) && !delaySpace)
        {
            audioManager.playSFX(audioManager.gunshot);

            Instantiate(projectilePrefab, transform.position, projectilePrefab.transform.rotation);
            delaySpace = true;
            StartCoroutine(Reset());

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
