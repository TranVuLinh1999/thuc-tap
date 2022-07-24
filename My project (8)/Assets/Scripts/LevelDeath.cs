using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelDeath : MonoBehaviour {

    public GameObject youFell;
    public GameObject levelAudio;
    public GameObject fadeOut;
    public AudioSource fallSound;
    public GameObject cameraUncouple;

    void OnTriggerEnter()
    {
        cameraUncouple.transform.parent = null;
        this.gameObject.GetComponent<BoxCollider>().enabled = false;
        StartCoroutine(YouFellOff());
    }


    IEnumerator YouFellOff ()
    {
        fallSound.Play();
        youFell.SetActive(true);
        levelAudio.SetActive(false);
        yield return new WaitForSeconds(2);
        fadeOut.SetActive(true);
        yield return new WaitForSeconds(1);
        GlobalScore.currentScore = 0;
        SceneManager.LoadScene(RedirectToLevel.redirectToLevel);
    }

}
