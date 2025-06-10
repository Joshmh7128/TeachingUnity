using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetPoint : MonoBehaviour
{
    public Vector2 resetPosition;
    public float radius;
    public PlayerController player;
    bool hasPlayer;

    private void Start()
    {
        player = FindObjectOfType<PlayerController>();
        
    }

    public void FixedUpdate()
    {
        if (Mathf.Abs(Vector2.Distance(transform.position, player.transform.position)) < radius && !hasPlayer)
        {
            hasPlayer = true;
            player.transform.position = resetPosition;
        }

        if (Mathf.Abs(Vector2.Distance(transform.position, player.transform.position)) > radius && hasPlayer)
        {
            hasPlayer = false;
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, radius);
    }
}
