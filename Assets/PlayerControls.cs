using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControls : MonoBehaviour {

    public KeyCode moveUp = KeyCode.W;
    public KeyCode moveDown = KeyCode.S;
    public float speed = 10.0f;
    public float boundY = 2.25f;
    private Rigidbody2D rb2d;
    private Vector3 target;
    Vector3 myPosition;
    private bool flag = false;
	// Use this for initialization
	void Start () {
        this.rb2d = GetComponent<Rigidbody2D>();
        this.target = this.rb2d.transform.position;
        myPosition = transform.position;
	}


    // Update is called once per frame
    void Update () {


        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            target = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            target.z = myPosition.z;
            target.x = myPosition.x;
            this.flag = true;
        }
       

        if (flag && !Mathf.Approximately(myPosition.magnitude, target.magnitude))
        {
            gameObject.transform.position = Vector3.Lerp(gameObject.transform.position, 
                                                         target,
                                                         1/(5f*(Vector3.Distance(gameObject.transform.position, target))));

        }else if (flag && Mathf.Approximately(gameObject.transform.position.magnitude, target.magnitude))
        {
            flag = false;
           
        }

    
	}
}
