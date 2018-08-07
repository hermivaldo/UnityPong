using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public static int PlayerScore1 = 0;
    public static int PlayerScore2 = 0;

    public GUISkin layout;

    GameObject theBall;

	// Use this for initialization
	void Start () {
        this.theBall = GameObject.FindGameObjectWithTag("Ball");
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public static void Score(string wallID){
        if (wallID == "RightWall"){
            PlayerScore1++;
        }else {
            PlayerScore2++;
        }
    }

    private void OnGUI()
    {
        GUI.skin = layout;
        GUI.Label(new Rect(Screen.width / 2 - 150 - 12, 20, 100, 100), "" + PlayerScore1);
        GUI.Label(new Rect(Screen.width / 2 + 150 + 12, 20, 100, 100), "" + PlayerScore2);

        if (GUI.Button(new Rect(Screen.width / 2 - 90, 35, 200, 53), "RESTART")){
            PlayerScore1 = 0;
            PlayerScore2 = 0;
            theBall.SendMessage("RestartGame", 0.5f, SendMessageOptions.RequireReceiver);
        }

        if (PlayerScore1 == 10){
            this.showWinner("PLAYER ONE WINS");

        }else if (PlayerScore2 == 20) {
            this.showWinner("PLAYER TWO WINS");
        }
    }

    private void showWinner(string winner){
        GUI.Label(new Rect(Screen.width / 2 - 150, 200, 2000, 1000), winner);
        theBall.SendMessage("ResetBall", null, SendMessageOptions.DontRequireReceiver);
    }
}
