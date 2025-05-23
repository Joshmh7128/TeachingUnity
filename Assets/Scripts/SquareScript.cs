using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SquareScript : MonoBehaviour
{
    // this is how fast we lerp
    float speed = 1.0f;
    // this is our lerp time
    double cltime = 0f;

    // FixedUpdate is called 50 times per second
    public void SlowUpdate(Color colA, Color colB, float ltime, double slowDelta)
    {
        // lerp towards our current color
        if (gameObject.GetComponent<SpriteRenderer>().isVisible)
            gameObject.GetComponent<SpriteRenderer>().color = Color.Lerp(colA, colB, (float)(cltime/(double)ltime));
        // set our speed
        if (cltime / ltime > 0.9f)
            speed = -1f;
        if (cltime / ltime < 0.1f)
            speed = 1f;
        // add our speed to our time
        cltime += (double)slowDelta * (double)speed;

    }
}
