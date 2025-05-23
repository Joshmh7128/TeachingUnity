using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class ElevatorScript : MonoBehaviour
{
    [SerializeField] float speed, distance;
    // where we start and how much we're adding
    [SerializeField] Vector2 startPos, addPos;

    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        // set our transform to our original position plus out added position
        transform.position = startPos + addPos;

        // only modify the Y axis of the added position
        addPos.y = Mathf.Sin(Time.time * speed) * distance;
        // addPos.x = Mathf.Cos(Time.time * speed) * distance;
    }
}
