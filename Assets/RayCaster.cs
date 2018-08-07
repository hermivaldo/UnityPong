using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayCaster : MonoBehaviour {

    private GameObject ball;
    public GameObject jogadorIA;
    private bool flag = false;
    Vector3 position;
	// Use this for initialization
	void Start () {
        this.ball = GameObject.FindGameObjectWithTag("Ball");

	}
	
	// Update is called once per frame
	void Update () {
	
        RayCast();
	}


    void RayCast(){
        Vector3 ballPos = ball.transform.position;

        RaycastHit2D hit = Physics2D.Raycast(ballPos, Vector2.left);
        if (hit.collider != null){
            
            if (ball.transform.position.x > 0){
                position = jogadorIA.transform.position;
                flag = true;
                ballPos.x = position.x;
                ballPos.z = position.z;

                //if (ball.transform.position.y > position.y && !Mathf.Approximately(jogadorIA.transform.position.magnitude, ball.transform.position.magnitude)){
                //    jogadorIA.transform.Translate(Vector2.up * 3.0f * Time.deltaTime);
                //}else if (ball.transform.position.y < position.y && 
                //          !Mathf.Approximately(jogadorIA.transform.position.magnitude, ball.transform.position.magnitude) ){
                //    jogadorIA.transform.Translate(Vector2.down * 3.0f * Time.deltaTime);
                //}
                if (flag && !Mathf.Approximately(position.magnitude, ballPos.magnitude))
                {
                    jogadorIA.transform.position = Vector3.Lerp(jogadorIA.transform.position,
                                                                ballPos,
                                                                1 / (5f * (Vector3.Distance(jogadorIA.transform.position, ballPos))));

                }
                else if (flag && Mathf.Approximately(jogadorIA.transform.position.magnitude, ballPos.magnitude))
                {
                    flag = false;

                }
            }

           
            //Debug.Log(hit.collider.name);
        }

        //if ()
    }
}
