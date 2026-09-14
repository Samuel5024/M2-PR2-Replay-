using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody rb; //reference to the Player's rigidbody coomponent
    public float forwardForce = 2000f;
    public float sidewaysForce = 500f;
    void FixedUpdate() //use fixed update for physics stuff
    {
        //rb.AddForce(0, 0, forwardForce * Time.deltaTime); //Time.deltaTime is the amount of time since computer drew the last frame

        if(Input.GetKey(KeyCode.RightArrow)) //if the player is pressing the Right Arrow key
        {
            MoveRight();
        }

        if(Input.GetKey(KeyCode.LeftArrow)) //if the player is pressing the Left Arrow key 
        {
            MoveLeft();
        }

        if(rb.position.y < -1f)
        {
            FindObjectOfType<GameManager>().EndGame();
        }
    }

    public void MoveRight()
    {
        rb.AddForce(sidewaysForce * Time.deltaTime, 0, 0, ForceMode.VelocityChange); //add a force to the right
    }

    public void MoveLeft()
    {
        rb.AddForce(-sidewaysForce * Time.deltaTime, 0, 0, ForceMode.VelocityChange); //add a force to the left (inverse (-) sidewaysForce)
    }

    public void ResetPosition()
    {
        transform.position = new Vector3(0.0f, 0.0f, 0.0f);
    }
}
