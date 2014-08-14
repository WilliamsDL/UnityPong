using UnityEngine;
using System.Collections;

public class GameSetup : MonoBehaviour
{
    #region Properties
    public Camera MainCam = new Camera();
    public BoxCollider2D TopWall = new BoxCollider2D();
    public BoxCollider2D BottomWall = new BoxCollider2D();
    public BoxCollider2D LeftWall = new BoxCollider2D();
    public BoxCollider2D RightWall = new BoxCollider2D();
    public Transform Player01;
    public Transform Player02;
    #endregion

    // Use this for initialization
	void Start () 
    {
        //Move each wall to its edge location.
        TopWall.size = new Vector2(MainCam.ScreenToWorldPoint(new Vector3(Screen.width * 2, 0, 0)).x, 1);
        TopWall.center = new Vector2(0, (float)(MainCam.ScreenToWorldPoint(new Vector3(0, Screen.height, 0)).y + .5));
        
        BottomWall.size = new Vector2(MainCam.ScreenToWorldPoint(new Vector3(Screen.width * 2, 0, 0)).x, 1);
        BottomWall.center = new Vector2(0, (float)(MainCam.ScreenToWorldPoint(new Vector3(0, 0, 0)).y - .5));

        LeftWall.size = new Vector2(1, MainCam.ScreenToWorldPoint(new Vector3(0, Screen.height * 2, 0)).y);
        LeftWall.center = new Vector2((float)(MainCam.ScreenToWorldPoint(new Vector3(0, 0, 0)).x - .5), 0);

        RightWall.size = new Vector2(1, MainCam.ScreenToWorldPoint(new Vector3(0, Screen.height * 2, 0)).y);
        RightWall.center = new Vector2((float)(MainCam.ScreenToWorldPoint(new Vector3(Screen.width, 0, 0)).x + .5), 0);

        Player01.position = new Vector3(MainCam.ScreenToWorldPoint(new Vector3(75, 0, 0)).x, 0, 0);
        Player02.position = new Vector3(MainCam.ScreenToWorldPoint(new Vector3(Screen.width - 75, 0, 0)).x, 0, 0);        

        //Play the sound track.
        audio.Play();
	}
}