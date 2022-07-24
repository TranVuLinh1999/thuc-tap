using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GlobalTimer : MonoBehaviour {

    public GameObject timeDisplay01;
    public GameObject timeDisplay02;
    public bool isTakingTime = false;
    public int theSeconds = 31;
    public static int extendScore;
    public GameObject timeUp;
    public GameObject fadeOut;
    public GameObject levelAudio;
    public bool finalTime = false;

	void Update () {
        extendScore = theSeconds;
        if (isTakingTime == false)
        {
            StartCoroutine(SubtractSecond());
        }
        if (theSeconds == 0)
        {
            finalTime = true;
            isTakingTime = true;
            StartCoroutine(TimeUp());
        }

	}

    IEnumerator SubtractSecond ()
    {
        if (finalTime == false)
        {
            isTakingTime = true;
            theSeconds -= 1;
            timeDisplay01.GetComponent<Text>().text = "" + theSeconds;
            timeDisplay02.GetComponent<Text>().text = "" + theSeconds;
            yield return new WaitForSeconds(1);
            isTakingTime = false;
        }
    }

    IEnumerator TimeUp()
    {
        timeUp.SetActive(true);
        levelAudio.SetActive(false);
        //yield return new WaitForSeconds(0.5f);
        fadeOut.SetActive(true);
        yield return new WaitForSeconds(1);
        GlobalScore.currentScore = 0;
        SceneManager.LoadScene(RedirectToLevel.redirectToLevel);
    }

}
