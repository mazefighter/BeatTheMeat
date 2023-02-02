using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayButton : MonoBehaviour
{
    [SerializeField] private Button playButton;
    [SerializeField] private Button exitButton;
    private float timer;
    private bool play = false;
    void Start()
    {
        Button playbtn = playButton.GetComponent<Button>();
        playbtn.onClick.AddListener(PlayClick);
        Button exitbtn = exitButton.GetComponent<Button>();
        exitbtn.onClick.AddListener(ExitClick);
    }

    private void ExitClick()
    {
        Application.Quit();
    }

    private void PlayClick()
    {
        timer = 0;
        play = true;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (play && timer > 0.5)
        {
            SceneManager.LoadScene("Level 1");
        }
    }
}
