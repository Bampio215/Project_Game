using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;


public class CharacterUIManager : MonoBehaviour
{
    public Property playerCharacter;
    public TextMeshProUGUI availablePointsText;
    public TextMeshProUGUI strengthText;
    public TextMeshProUGUI speedText;
    public TextMeshProUGUI healthText;
    public TextMeshProUGUI cooldownText;
    public TextMeshProUGUI levelText;

    public TMP_InputField levelTextField;
    public TMP_Dropdown difficultyManager;
    void Start()
    {
        playerCharacter = new Property();
        difficultyManager.value = 1;
        UpdateUI();
        
    }
    public void Update()
    {
    }
    public void OnLevelUp()
    {
        playerCharacter.LevelUp();
        UpdateUI();
    }

    public void OnLevelDown()
    {
        playerCharacter.LevelDown();
        UpdateUI();
    }
    public void OnIncreaseStat(string statName)
    {
        if (playerCharacter.UpdateStat(statName, 1)) // Tăng 1 điểm
        {
            UpdateUI();
        }
    }
    private void UpdateUI()
    {
        availablePointsText.text = $"Points: {playerCharacter.AvailablePoints}";
        strengthText.text = $"Strength: {playerCharacter.Strength}";
        speedText.text = $"Speed: {playerCharacter.Speed}";
        healthText.text = $"Health: {playerCharacter.Health}";
        cooldownText.text = $"Cooldown: {playerCharacter.Cooldown}";
        levelText.text = $"Level {playerCharacter.Level}";
        levelTextField.text = playerCharacter.Level.ToString();
    }

    public void Play(GameObject panel)
    {
        panel.SetActive(false);
    }

    public void PlayContinue(GameObject panel)
    {
        panel.SetActive(false);
    }
    public void SetDifficulty()
    {
        switch (difficultyManager.value)
        {
            case 0:
                Time.timeScale = 0.8f; // Chậm hơn
                Debug.Log("err "+0);
                break;
            case 1:

                Time.timeScale = 1f; 
                break;
            case 2:
                Time.timeScale = 1.2f; // Nhanh hơn
                break;
        }
    }
}

