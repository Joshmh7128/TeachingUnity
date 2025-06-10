using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // this is our player's rigidbody
    [SerializeField] Rigidbody2D playerBody;
    [SerializeField] float moveSpeed; // how fast do we move?
    [SerializeField] float jumpPower; // how high do we jump?
    [SerializeField] bool grounded; // are we grounded?
    public string lastArea; // last area

    // Start is called before the first frame update
    void Start()
    {
        // get our player's rigidbody
        playerBody = GetComponent<Rigidbody2D>();

        GameObject.FindObjectOfType<TelemetryHandler>().startTime = System.DateTime.Now;
    }

    /// <summary>
    /// We want to use the fixed update instead of the update because we are doing physics based movement
    /// </summary>
    void FixedUpdate()
    {
        // process our player's movement
        ProcessMovement();
    }

    // we use update to capture on key down inputs
    private void Update()
    {
        // process our player's jump
        ProcessJump();
    }

    /// <summary>
    /// This function processes movement applies horizontal movement to the player
    /// </summary>
    void ProcessMovement()
    {
        // each frame create a new movement vector
        Vector2 move = Vector2.zero;
        // assign our movement to the vector
        if (Input.GetKey(KeyCode.D))
            move.x = 1;
        if (Input.GetKey(KeyCode.A))
            move.x = -1;

        // apply our move to the player
        playerBody.AddForce(move * moveSpeed, ForceMode2D.Force);
    }

    /// <summary>
    /// This function processes the jump button input, and applies jump movement to the player
    /// </summary>
    void ProcessJump()
    {

        Vector2 dif = new Vector2(0, 0.7f);
        // check if we are on the ground or not
        grounded = Physics2D.Raycast(playerBody.position - dif, Vector2.down, 0.1f);

        if (Input.GetKeyDown(KeyCode.Space) && grounded)
        {
            GameObject.FindObjectOfType<TelemetryHandler>().jumps += 1;
            playerBody.AddForce(Vector2.up * jumpPower, ForceMode2D.Impulse);
        }
    }

    /// <summary>
    /// Drawing debug graphics
    /// </summary>
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawRay(playerBody.position- new Vector2(0, 0.7f), Vector2.down);
    }
}

