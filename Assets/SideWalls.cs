using UnityEngine;
using System.Collections;

public class SideWalls : MonoBehaviour {

	void OnTriggerEnter2D (Collider2D hitInfo) 
    {
	    if (hitInfo.name == "Ball")
        {
            GameManager.Score(this.name);
            //Play the click sound.            
            audio.Play();
            hitInfo.gameObject.SendMessage("ResetBall");
        }        
	}
}
