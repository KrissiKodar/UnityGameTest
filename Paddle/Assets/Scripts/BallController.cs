using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    
    public Rigidbody2D body;
    public Vector2 direction;
    public float impulse;
    public float maxReflectAngle;
    public float diameter;
    float radius;
    Vector2 startPosition;
    float currentDiameter;
    float scale;
    float yLevelBound;
    float xLevelBound;
    
    
    // Start is called before the first frame update
    void Start()
    {
        yLevelBound = MeteorSpawner.yLevelBound;
        xLevelBound = MeteorSpawner.xLevelBound;

        currentDiameter = GetComponent<SpriteRenderer>().sprite.bounds.size.x;
        scale = diameter / currentDiameter;
        radius = diameter / 2f;
        transform.localScale = new Vector3(scale, scale, 1);
        Debug.Log(xLevelBound);
        Debug.Log(yLevelBound);
        
        startPosition = GetRandomStartPosition();
        Reset();
    }

    private Vector3 GetRandomStartPosition()
    {
        // Determine the direction - beyond either the horizontal or vertical bounds
        bool isHorizontal = Random.value > 0.5f;

        if (isHorizontal)
        {
            // Beyond horizontal bounds
            float xPosition = Random.value > 0.5f ? xLevelBound + Random.Range(1f, 5f) : -xLevelBound - Random.Range(1f, 5f);
            float yPosition = Random.Range(-yLevelBound, yLevelBound);
            return new Vector3(xPosition, yPosition, 0);
        }
        else
        {
            // Beyond vertical bounds
            float xPosition = Random.Range(-xLevelBound, xLevelBound);
            float yPosition = Random.value > 0.5f ? yLevelBound + Random.Range(1f, 5f) : -yLevelBound - Random.Range(1f, 5f);
            return new Vector3(xPosition, yPosition, 0);
        }
    }

    // Update is called once per frame
    void Update()
    {
        /* float ballAngle = Vector2.Angle(transform.position, body.velocity);
        float x = transform.position.x;
        float y = transform.position.y;
        
        
        if (ballAngle < 90 && (x < -xLevelBound - radius || x > xLevelBound + radius || 
                               y < -yLevelBound - radius || y > yLevelBound + radius))
        {
            Reset();
        }  */
    }


    void FixedUpdate()
    {
        float ballAngle = Vector2.Angle(transform.position, body.velocity);
        float x = transform.position.x;
        float y = transform.position.y;
        
        
        if (ballAngle < 90 && (x < -xLevelBound - radius || x > xLevelBound + radius || 
                               y < -yLevelBound - radius || y > yLevelBound + radius))
        {
            Reset();
        } 
    }


    public void Reset()
    {
        Vector3 startPosition = GetRandomStartPosition();
        transform.position = startPosition;
        // Calculate direction towards the center (0,0)
        Vector3 targetPosition = Vector3.zero; // Center of the screen
        Vector3 direction = targetPosition - startPosition; // Direction from start to center


        body.velocity = direction.normalized * impulse;

        // Reset score
        //GameManager.instance.score = 0;
    }
    
    void OnTriggerEnter2D(Collider2D other)
    {


        if (other.CompareTag("Paddle"))
        {
            Rigidbody2D paddleRigidbody = other.attachedRigidbody;
            // Handle paddle collision
            Debug.Log("Paddle hit");
            if (paddleRigidbody != null)
            {
                Debug.Log("Paddle physics");
                AudioSource paddleAudio = other.GetComponent<AudioSource>();
                if (paddleAudio != null) paddleAudio.Play();

                Vector2 paddleNormal = other.transform.up;

                // Don't bounce balls that enter from behind
                float ballAngle = Vector2.Angle(paddleNormal, body.velocity);

                if (ballAngle < 90)
                {
                    Debug.Log("hit");
                    // Reflect the ball's velocity about the paddle normal to get the bounce velocity
                    Vector2 reflectedVelocity = Vector2.Reflect(body.velocity, paddleNormal);

                    // Now we clamp the reflection angle to maxReflectAngle
                    // We want the signed angle so we know which direction to rotate
                    float reflectAngle = Vector2.SignedAngle(paddleNormal, reflectedVelocity);

                    // Check if the bounce is too shallow
                    if (Mathf.Abs(reflectAngle) > maxReflectAngle)
                    {
                        // figure out how far past the maximum angle we are
                        float deltaAngle = (Mathf.Sign(reflectAngle) * maxReflectAngle) - reflectAngle;

                        // A quaternion represents a rotation, in this case about the Z axis
                        Quaternion clampRotation = Quaternion.Euler(0, 0, deltaAngle);

                        // Multiplying a vector by a quaternion gives you that vector rotated by the quaternion
                        reflectedVelocity = clampRotation * reflectedVelocity;
                    }

                    // Update the ball's velocity to bounce it away
                    body.velocity = -reflectedVelocity;

                    // Score points!
                    GameManager.instance.score++;


                    //Instantiate(Ball);
                }
            }
        }

        // Check if the collided object is the blackhole
        else if (other.CompareTag("Blackhole"))
        {
            Rigidbody2D blackholeRigidbody = other.attachedRigidbody;
            // Handle blackhole collision
            
            if (blackholeRigidbody != null)
            {
                AudioSource blackholeAudio = other.GetComponent<AudioSource>();
                if (blackholeAudio != null) blackholeAudio.Play();
                // Subtract points!
                //GameManager.instance.score--;
                // Reset score
                GameManager.instance.score = 0;
                //Instantiate(Ball);
                // Reset time
                GameManager.instance.timeElapsed = 0;
                Destroy(gameObject);
                

            }
        }
    }
}
