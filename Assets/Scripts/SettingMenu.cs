using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class SettingMenu : MonoBehaviour
{
    public AudioMixer audioMixer;
    public GameObject[] panels; // Danh sách tất cả các Panel
    private Stack<GameObject> panelHistory = new Stack<GameObject>(); // Lưu lịch sử Panel
    private GameObject currentPanel; // Panel đang hiển thị
    public void SetFullScreen(bool isFullscreen)
    {
        Screen.fullScreen = isFullscreen;
    }
    public void SetVolume(float volume)
    {
        audioMixer.SetFloat("volume",volume);
    }
    public void SetQuanity(int qualityIndex)
    {
        QualitySettings.SetQualityLevel(qualityIndex);
    }
    public void Start()
    {
        if (panels.Length > 0)
        {
            currentPanel = panels[0]; // Gán panel đầu tiên làm panel hiện tại
            currentPanel.SetActive(true);
        }
    }
    public void Quit()
    {
        Application.Quit();
    }




    // Hiển thị một Panel mới
    public void ShowPanel(GameObject panelToShow)
    {
        // Nếu đang có Panel hiển thị, lưu nó vào Stack
        if (currentPanel != null)
        {
            panelHistory.Push(currentPanel);
            currentPanel.SetActive(false);
        }

        // Hiển thị Panel mới
        currentPanel = panelToShow;
        currentPanel.SetActive(true);
    }

    // Quay lại Panel trước đó
    public void Back()
    {
        // Nếu có Panel trong lịch sử, lấy ra và hiển thị
        if (panelHistory.Count > 0)
        {
            currentPanel.SetActive(false);
            currentPanel = panelHistory.Pop();
            currentPanel.SetActive(true);
        }
    }
}
