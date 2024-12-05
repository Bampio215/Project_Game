using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float horizontalInput;
    public float speed = 10.0f;
    private float xRange = 20;

    public GameObject projectilePrefab;
    private bool delaySpace = false;

    // Start is called before the first frame update
    void Start()
    {

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
            Instantiate(projectilePrefab, transform.position, projectilePrefab.transform.rotation);
            delaySpace = true;
            StartCoroutine(Reset());

        }
        horizontalInput = Input.GetAxis("Horizontal");

        transform.Translate(Vector3.right * horizontalInput * Time.deltaTime * speed);
    }
    IEnumerator Reset()
    {
        yield return new WaitForSeconds(0.5f);
        delaySpace = false;
    }
}
