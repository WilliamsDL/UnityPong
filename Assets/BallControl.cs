using UnityEngine;
using System.Collections;

public class BallControl : MonoBehaviour {

    float ballSpeed = 100;

	// Use this for initialization
    IEnumerator Start() 
    {
        transform.position = new Vector3(0, 0, 0);        
        yield return StartCoroutine(Wait(2));
        GoBall();
	}

    public IEnumerator Wait(float seconds)
    {        
        yield return new WaitForSeconds(seconds);     
    }

    void Update()
    {
        //Sometimes the ball speed can get too slow.  Make sure this doesn't happen.
        float xVelocity = rigidbody2D.velocity.x;
        if (xVelocity < 18 && xVelocity > -18 && xVelocity != 0)
        {
            if (xVelocity > 0)
                rigidbody2D.AddForce(new Vector2(20, 0));
            else
                rigidbody2D.AddForce(new Vector2(-20, 0));
        }
    }
		
    void OnCollisionEnter2D(Collision2D colliderInfo) 
    {
	    if (colliderInfo.collider.tag == "Player")
        {
            //We hit the player.            
            rigidbody2D.velocity = new Vector2(rigidbody2D.velocity.x, (rigidbody2D.velocity.y / 2) + (colliderInfo.collider.rigidbody2D.velocity.y / 3));
            //Play the click sound.
            audio.pitch = Random.Range(0.8f, 1.2f);
            audio.Play();
        }
	}
    
    IEnumerator ResetBall()
    {        
        rigidbody2D.velocity = new Vector2(0, 0);
        transform.position = new Vector3(0, 0, 0);        
        yield return StartCoroutine(Wait(2));
        GoBall();
    }

    void GoBall()
    {
        float goBallSpeed = 0;
        if (Random.Range(-100, 100) > 0)
            goBallSpeed = ballSpeed;
        else
            goBallSpeed = -ballSpeed;

        rigidbody2D.AddForce(new Vector2(goBallSpeed, Random.Range(0, 100)));	
    }
}
