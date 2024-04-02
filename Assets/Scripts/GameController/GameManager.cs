using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Events;

public class GameManager : MonoBehaviour
{
    [SerializeField] GameObject gameOverUI;
    [SerializeField] GameObject iconsUI;

    // Start is called before the first frame update
    void Start()
    {
        gameOverUI.SetActive(false);
        GameEvents.PlayerDead.AddListener(GameOver);
    }
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.R))
        {
            Reset();
        }
    }
    void GameOver()
    {
        gameOverUI.SetActive(true);
        iconsUI.SetActive(false);
    }

    void Reset()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

}
