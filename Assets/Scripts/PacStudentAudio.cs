using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    public AudioClip MoveSoundEffect;

    // Start is called before the first frame update
    void Start()
    {

        StartCoroutine(playSoundEffect());
    }

    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator playSoundEffect()
    {
        while (true)
        {
            GetComponent<AudioSource>().clip = MoveSoundEffect;
            GetComponent<AudioSource>().Pause();
            yield return new WaitForSeconds(4.5f);
            GetComponent<AudioSource>().Play();
            yield return new WaitForSeconds(6);
        }
    }
}
