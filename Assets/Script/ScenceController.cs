using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScenceController : MonoBehaviour
{
    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        // Gọi hàm LoadPlayerData của CharItem khi scene mới được tải
        CharItem.instance.LoadDataPlayer();
    }

    public void LoadNextScene()
    {
        // Chuyển đến scene mới
        SceneManager.LoadScene("NextScene");
    }
}
