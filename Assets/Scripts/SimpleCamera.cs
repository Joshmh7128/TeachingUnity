using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleCamera : MonoBehaviour
{

    [SerializeField] float movespeed;
    [SerializeField] Camera cam;

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

        transform.position = Vector2.Lerp(transform.position, (Vector2)transform.position + input, movespeed * Time.deltaTime);
        transform.position = new Vector3(transform.position.x, transform.position.y, -20);

        if (Input.GetKey(KeyCode.Minus))
            cam.orthographicSize += 1;
        if (Input.GetKey(KeyCode.Plus))
            cam.orthographicSize -= 1;
    }
}
