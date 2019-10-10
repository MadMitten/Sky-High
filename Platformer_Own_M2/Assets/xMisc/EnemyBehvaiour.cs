using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehvaiour : MonoBehaviour {

    public AudioClip Bones;
    public float speed;
	private bool movingRight = true;
	public Transform groundDetection;
	public bool grounded = false;
	public Transform groundCheck;
	Animator anim;


	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
        if (GameBehaviour.instance.paused == false)
        {
            transform.Translate(Vector2.right * speed * Time.deltaTime);
            RaycastHit2D groundInfo = Physics2D.Raycast(groundDetection.position, Vector2.down, 2f);

            if (groundInfo.collider == false)
            {
                if (movingRight == true)
                {
                    transform.eulerAngles = new Vector3(0, -180, 0);
                    movingRight = false;
                }
                else
                {
                    transform.eulerAngles = new Vector3(0, 0, 0);
                    movingRight = true;
                }//End of else
            }//End of if
        }
	}//End of update

	void checkIfGrounded()
	{
		//grounded = Physics2D.OverlapCircle(groundCheck.position, groundRadius, whatIsGround);
	}

	public void EnemyDestroyed()
	{
		/*if (collision.gameObject.CompareTag ("Player")) {
			if (PlayerMovement.instance.grounded == false) {
				Destroy(this.gameObject);

			}
		}*/
	}//End of EnemyDestroyed.

    private void OnCollisionEnter2D(Collision2D collision)
    {
    //    Debug.Log("Hit");
        if (collision.gameObject.CompareTag("Player"))
        {
            if (PlayerMovement.instance.grounded == false)
            {
                PlayerMovement.instance.jump();
                killEnemy();
            }
            else
            {
                Destroy(collision.gameObject);
                GameBehaviour.instance.loseLife();
            }
        }
        if (collision.gameObject.CompareTag("PlayerProjectile"))
        {
            killEnemy();
        }
        if (collision.gameObject.tag == "Player")
        {
            AudioSource.PlayClipAtPoint(Bones, gameObject.transform.position);
        }


    }

    private void killEnemy()
    {
        anim.SetBool("Dead", true);
        speed = 0;
        this.gameObject.GetComponent<BoxCollider2D>().isTrigger = true;
        Destroy(this.gameObject, .5f);
    }

}//End of class
