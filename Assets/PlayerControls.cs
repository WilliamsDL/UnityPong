using UnityEngine;
using System.Collections;

public class PlayerControls : MonoBehaviour
{
    #region Members
    public KeyCode moveUp = new KeyCode();
    public KeyCode moveDown = new KeyCode();
    public float speed = 10;    
    #endregion

	// Update is called once per frame
	void Update ()
    {        
        if (Input.GetKey(moveUp))
        {            
            this.rigidbody2D.velocity = new Vector2(0 , speed);
        }
        else if (Input.GetKey(moveDown))
        {
            //Reverse the speed by multiplying by -1.
            this.rigidbody2D.velocity = new Vector2(0, speed * -1);
        }
        else
        {
            this.rigidbody2D.velocity = new Vector2(0, 0);
        }
        
        //Ensure that when the ball hits the paddles, the paddles are not affected in an x direction.
        this.rigidbody2D.velocity = new Vector2(0, this.rigidbody2D.velocity.y);
    }
}
