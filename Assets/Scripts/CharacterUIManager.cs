﻿using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor.UI;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

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

    void Start()
    {
        playerCharacter = new Property();
        UpdateUI();
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
}
