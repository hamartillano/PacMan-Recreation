using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnClickLevel1()
    {
        SceneManager.LoadScene("PacMan");
    }

    public void OnClickExit()
    {
        SceneManager.LoadScene("StartScene");
    }
}
