using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour
{
    #region "Members"
    public static int PlayerScore01 = 0;
    public static int PlayerScore02 = 0;
    public GUISkin theSkin;
    public Transform theBall;
    #endregion

	public static void Score (string wallName) 
    {
	    if (wallName == "LeftWall")
        {
            PlayerScore02++;
        }
        else
        {
            PlayerScore01++;
        }        
	}

    public void OnGUI()
    {
        GUI.skin = theSkin;
        GUI.Label (new Rect(Screen.width / 2 - 150 - 18, 20, 400, 400), PlayerScore01.ToString());
        GUI.Label(new Rect(Screen.width / 2 + 150 - 18, 20, 400, 400), PlayerScore02.ToString());        

        if (GUI.Button(new Rect(Screen.width / 2 - (121 / 2), 35, 121, 53), "RESET"))
        {
            PlayerScore01 = 0;
            PlayerScore02 = 0;
            theBall.gameObject.SendMessage("ResetBall");
        }
    }

    void Start()
    {
        theBall = GameObject.FindGameObjectWithTag("Ball").transform;
    }
}
