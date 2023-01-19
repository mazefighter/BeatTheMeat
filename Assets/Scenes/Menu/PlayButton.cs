using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayButton : MonoBehaviour
{
    [SerializeField] private Button playButton;
    void Start()
    {
        Button playbtn = playButton.GetComponent<Button>();
        playbtn.onClick.AddListener(PlayClick);
    }

    private void PlayClick()
    {
        SceneManager.LoadScene("Level 1");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
