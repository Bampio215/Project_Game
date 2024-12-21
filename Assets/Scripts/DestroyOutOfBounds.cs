using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOutOfBounds : MonoBehaviour
{
    // Start is called before the first frame update
    private float topBound = 30;

    private float lowBound = -10;

    private Health health;
    void Start()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player != null)
        {
            health = player.GetComponent<Health>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.z > topBound)
        {
            Destroy(gameObject);
        }
        else
        {
            if (transform.position.z < lowBound || transform.position.x < 3 * lowBound || transform.position.x > -3 * lowBound)
            {
                if (health != null)
                {
                    health.TakeDamage(1);
                }

                Destroy(gameObject);
            }
        }
    }





}
