using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TelemetryArea : MonoBehaviour
{
    public string areaName;
    public float radius;
    public PlayerController player;
    public bool hasPlayer;

    private void Start()
    {
        player = FindObjectOfType<PlayerController>();
        gameObject.name = areaName;
    }

    public void FixedUpdate()
    {
        if (Mathf.Abs(Vector2.Distance(transform.position, player.transform.position)) < radius && !hasPlayer)
        {
            hasPlayer = true;
            player.lastArea = areaName;
            FindObjectOfType<TelemetryHandler>().Send();
        }

        if (Mathf.Abs(Vector2.Distance(transform.position, player.transform.position)) > radius && hasPlayer)
        {
            hasPlayer = false;
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, radius);
    }
}
