using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TelemetryPlayerPath : MonoBehaviour
{
    public List<Vector2> pathPoints = new List<Vector2>();
    Vector2 playbackPoint;
    bool playback;
    int cp;

    private void Start()
    {
        StartCoroutine(SlowTick());
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F4))
            StartPlayback();
    }

    private void FixedUpdate()
    {
        if (playback)
            playbackPoint = Vector2.MoveTowards(playbackPoint, pathPoints[cp], Vector2.Distance(playbackPoint, pathPoints[cp]) / 0.1f);
    }

    public IEnumerator SlowTick()
    {
        if (playback)
            UpdatePlaybackPoint();
        else
            RecordPosition();

        yield return new WaitForSecondsRealtime(0.1f);
        StartCoroutine(SlowTick());
    }    

    public void RecordPosition()
    {
        // (0.00001,-1.40020292)
        pathPoints.Add((FindObjectOfType<PlayerController>().transform.position));
    }

    void StartPlayback()
    {
        playback = true;
        playbackPoint = pathPoints[0];
    }

    void UpdatePlaybackPoint()
    {
        playbackPoint = pathPoints[cp];
        if (cp + 1 < pathPoints.Count)
            cp++;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawSphere(playbackPoint, 0.5f);
    }
}
