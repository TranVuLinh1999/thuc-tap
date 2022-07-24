using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelAudioSelect : MonoBehaviour {

    public GameObject[] levelAudio;
    public int audioNumber;

	void Start () {
        audioNumber = Random.Range(0, 4);
        levelAudio[audioNumber].SetActive(true);
	}

}
