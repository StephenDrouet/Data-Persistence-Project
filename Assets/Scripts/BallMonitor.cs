using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMonitor : MonoBehaviour
{
    private Rigidbody playerRb;
    public ParticleSystem explosionParticle;
    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("Velocity: " + playerRb.velocity.magnitude);
        fixVelocity();
    }

    void fixVelocity()
    {
        if(playerRb.velocity.magnitude < 60 || playerRb.velocity.magnitude > 61)
        {
            Vector3 direction = playerRb.velocity.normalized;
            playerRb.velocity = direction * 60f;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        explosionParticle.Play();
        if (collision.gameObject.CompareTag("Block"))
        {
            
            Destroy(collision.gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("GameOver"))
        {
            Debug.Log("Game Over");
            Destroy(gameObject);
        }
    }
}