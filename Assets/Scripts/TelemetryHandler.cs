using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using System.Linq;
using System;
using UnityEngine.UIElements;

public class TelemetryHandler : MonoBehaviour
{
    public int jumps;
    public DateTime startTime;

    // our form response url
    string URL = "https://docs.google.com/forms/d/e/1FAIpQLSf1n1YvoKSPfEaeX6_Bkq6_gnX41kzyt7YPmM4EB0Hm6dI2ig/formResponse";

    private void Start()
    {
        StartCoroutine("StartPost");
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F3))
        {
            Send();
            Debug.Log("Telemetry Request...");
        }
    }

    // send feedback
    public void Send()
    {
        Debug.Log("sending...");
        // send info
        StartCoroutine("Post");
    }

    IEnumerator StartPost()
    {
        // create a new form
        WWWForm form = new WWWForm();

        // add the field for the system date and time
        form.AddField("entry.998430378", (System.DateTime.Now).ToString());
        // add the jumps at the time of recording
        form.AddField("entry.291207633", jumps.ToString());
        // location data
        form.AddField("entry.709403741", "NEW PLAYER");
        // add the time since the start of play
        form.AddField("entry.480743022", (System.DateTime.Now - startTime).ToString());



        // perform the post request
        UnityWebRequest www = UnityWebRequest.Post(URL, form);

        if (www != null)
            Debug.Log("request sent!");

        // return the send request
        yield return www.SendWebRequest();
    }

    // coroutine to post
    IEnumerator Post()
    {
        // create a new form
        WWWForm form = new WWWForm();

        // add the field for the system date and time
        form.AddField("entry.998430378", (System.DateTime.Now).ToString());
        // add the jumps at the time of recording
        form.AddField("entry.291207633", jumps.ToString());
        // location data
        form.AddField("entry.709403741", FindObjectOfType<PlayerController>().lastArea);
        // add the time since the start of play
        form.AddField("entry.480743022", (System.DateTime.Now - startTime).ToString());

       

        // perform the post request
        UnityWebRequest www = UnityWebRequest.Post(URL, form);

        if (www != null)
            Debug.Log("request sent!");

        // return the send request
        yield return www.SendWebRequest();
    }
}
