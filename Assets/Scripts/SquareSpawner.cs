using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;

public class SquareSpawner : MonoBehaviour
{
    public GameObject square;
    (List<Color> a, List<Color> b) colors;
    List<float> ltimes;
    public float xCount, yCount, tCount;
    public float slowFPS = 20; // how many frames per second does the slow tick run?

    private List<SquareScript> squareScripts = new List<SquareScript>();

    private void Start()
    {
        // set tCount
        tCount = xCount * yCount;

        SpawnSquares();

        // then start the slow update
        StartCoroutine(SlowUpdateTicker());
    }

    /// <summary>
    /// This will create all of the squares as requested by the xCount and yCount
    /// </summary>
    void SpawnSquares()
    {
        // for each int in X and Y, run...
        for (int x = 0; x < xCount; x++)
            for (int y = 0; y < yCount; y++)
            {
                // spawn a square at the designated location
                squareScripts.Add(Instantiate(square, new Vector2(x, y), Quaternion.identity).GetComponent<SquareScript>());
            }

        // initialize our colors
        InitializeColors();
    }

    int groupAmount = 40;
    int group = 0;
    int groupStart = 1;

    /// <summary>
    /// Runs our slow update
    /// </summary>
    /// <returns></returns>
    IEnumerator SlowUpdateTicker()
    {
        // wait
        yield return new WaitForSecondsRealtime(1f/slowFPS);
        // run slow update
        GroupUpdate();
        // iterate group
        group++;
        group = group >= groupAmount ? 0 : group;
        groupStart = (squareScripts.Count / groupAmount) * (group);
        // rerun
        StartCoroutine(SlowUpdateTicker());
    }

    (List<Color> ac, List<Color> bc) InitializeColors()
    {
        colors = (new List<Color>(), new List<Color>());

        for (int i = 0; i <= tCount; i++)
        {
            colors.a.Add(new Color(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f), 1f));
            colors.b.Add(new Color(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f), 1f));
        }

        Debug.Log(colors.a.Count);
        Debug.Log(colors.b.Count);

        InitializeLtimes();

        // then return
        return (colors.a, colors.b);
    }

    // init our ltimes
    List<float> InitializeLtimes()
    {
        ltimes = new List<float>();
        for (int i = 0; i <= tCount; i++)
            ltimes.Add(Random.Range(0.1f, 0.25f));

        return ltimes;
    }    

    // do slow stuff!
    void GroupUpdate()
    {
        for (int i = (groupStart); i < (groupStart) + (squareScripts.Count / groupAmount); i++)
        {
            squareScripts[i].SlowUpdate(colors.a[i], colors.b[i], ltimes[i], 1.00/(double)slowFPS);
        }
    }
}
