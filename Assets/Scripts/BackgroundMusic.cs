using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundMusic : MonoBehaviour
{
    public AudioClip PacStudentIntro;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(playSound());
    }

    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator playSound()
    {
        //Intro
        GetComponent<AudioSource>().clip = PacStudentIntro;
        GetComponent<AudioSource>().Play();
        yield return new WaitForSeconds(PacStudentIntro.length);
    }
}
