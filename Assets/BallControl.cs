using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallControl : MonoBehaviour {

    private Rigidbody2D rb2d;
    private Vector2 vel;

    public float speed = 300f;

    void GoBall(){
        float rand = Random.Range(0, 2);
        if (rand < 1) {
            this.rb2d.velocity = Vector2.right * (speed * Time.deltaTime);
        } else {
            this.rb2d.velocity = Vector2.left * (speed * Time.deltaTime);
        }
    }

    void ResetBall(){
        vel = Vector2.zero;
        this.rb2d.velocity = vel;
        transform.position = Vector2.zero;
    }

    void RestartGame(){
        ResetBall();
        Invoke("GoBall", 1);
    }

    float hitFactory(Vector2 ballPos, Vector2 racPost, float racHei){
        return (ballPos.y - racPost.y) / racHei;
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.collider.CompareTag("Player2"))
        {
            float y = hitFactory(transform.position,
                                 coll.transform.position,
                                 coll.collider.bounds.size.y);
            Vector2 dir = new Vector2(-1, y).normalized;

            rb2d.velocity = (dir * (speed * Time.deltaTime));
        }else if (coll.collider.CompareTag("Player1")){
            float y = hitFactory(transform.position,
                                 coll.transform.position,
                                 coll.collider.bounds.size.y);
            Vector2 dir = new Vector2(1, y).normalized;

            rb2d.velocity = (dir *(speed * Time.deltaTime));
        }
    }

	// Use this for initialization
	void Start () {
        this.rb2d = GetComponent<Rigidbody2D>();
        Invoke("GoBall", 2);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
