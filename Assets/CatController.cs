using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatController : MonoBehaviour {

    public float MoveForce = 3f;
    public float JumpForce = 5f;
    public float WorldDrag = 1.9f;
    public string Env = "indoor";
    private Rigidbody2D body;
    private SpriteRenderer render;
    public bool CanJump = true;
	// Use this for initialization
	void Start () {
        this.body = this.gameObject.GetComponent<Rigidbody2D>();
        this.render = this.gameObject.GetComponent<SpriteRenderer>();
        this.Env = "indoor";
    }

    void UseInDoorControl()
    {
        if (Input.GetButton("Right"))
        {
            
            this.body.AddForce(new Vector2(this.MoveForce, 0), ForceMode2D.Force);
            this.render.flipX = false;
        }
        if (Input.GetButton("Left"))
        {
            this.body.AddForce(new Vector2(-this.MoveForce, 0), ForceMode2D.Force);
            this.render.flipX = true;
        }
        if (Input.GetButton("Up"))
        {
            //open door 
            //clap up

        }
        if (Input.GetButton("Down"))
        {
            //squat
            //clap down
        }
        if (Input.GetButton("Jump") && System.Math.Abs(this.body.velocity.y) < 0.01)
        {
            this.body.AddForce(new Vector2(0, this.JumpForce), ForceMode2D.Impulse);
        }
        this.CanJump = System.Math.Abs(this.body.velocity.y) < 0.01;
        AutoFriction();
    }

    void UseOutDoorControl()
    {
        if (Input.GetButton("Right"))
        {
            this.body.AddForce(new Vector2(this.MoveForce, 0), ForceMode2D.Force);
        }
        if (Input.GetButton("Left"))
        {
            this.body.AddForce(new Vector2(-this.MoveForce, 0), ForceMode2D.Force);
        }
        if (Input.GetButton("Up"))
        {
            this.body.AddForce(new Vector2(0, this.MoveForce), ForceMode2D.Force);

        }
        if (Input.GetButton("Down"))
        {
            this.body.AddForce(new Vector2(0, -this.MoveForce), ForceMode2D.Force);
        }

    }

    void AutoFriction()
    {
        this.body.drag = System.Math.Abs(this.body.velocity.x) * this.WorldDrag;
    }
    // Update is called once per frame
    void Update () {
        switch (this.Env)
        {
            case "indoor":
                UseInDoorControl();
                break;
            case "outdoor":
                UseOutDoorControl();
                break;
            default:
                break;
        }
        
    }
}
