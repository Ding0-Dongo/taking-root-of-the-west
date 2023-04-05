using UnityEngine;

public class playerMovement : MonoBehaviour
{

    public int speed = 10;
    private bool facingRight = true;
    private Rigidbody2D characterBody;
    private Vector2 velocity;
    private Vector2 inputMovement;

    // Start is called before the first frame update

	private void Flip()
	{
		// Switch the way the player is labelled as facing.
		facingRight = !facingRight;

		// Multiply the player's x local scale by -1.
		Vector2 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	}

    void Start()
    {
        velocity = new Vector2(speed, speed) * 3;
        characterBody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
      inputMovement = new Vector2(
        Input.GetAxisRaw("Horizontal"),
        0
      );   
    }

    private void FixedUpdate()
    {
        if(Input.GetAxisRaw("Horizontal") < 0 && facingRight){
            Flip();
        }
        else if(Input.GetAxisRaw("Horizontal") > 0 && !facingRight){
            Flip();
        }
        Vector2 delta = inputMovement * velocity * Time.deltaTime;
        Vector2 newPosition = characterBody.position + delta;
        characterBody.MovePosition(newPosition);
    }


}
