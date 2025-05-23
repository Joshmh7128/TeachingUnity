using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleCamera : MonoBehaviour
{

    [SerializeField] float lerpspeed, movespeed;
    [SerializeField] Camera cam;
    Vector2 targetpos;

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    void Move()
    {
        float hax = Input.GetAxis("Horizontal");
        float vax = Input.GetAxis("Vertical");

        Vector2 input = new Vector2(hax, vax);

        targetpos = Vector2.Lerp(targetpos, (Vector2)targetpos + (input * movespeed), lerpspeed * Time.deltaTime);
        transform.position = Vector2.Lerp(transform.position, targetpos, lerpspeed * Time.deltaTime);
        transform.position = new Vector3(transform.position.x, transform.position.y, -20);

        if (Input.GetKey(KeyCode.Minus))
            cam.orthographicSize += 0.5f;
        if (Input.GetKey(KeyCode.Equals))
            cam.orthographicSize -= 0.5f;
    }
}
