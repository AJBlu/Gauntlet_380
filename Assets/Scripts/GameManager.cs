using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : Singleton<GameManager>
{
    //UI elemenets that are needed for the game with each character having certain things tracked.
    private int _level;
    private int _elfScore, _warriorScore, _wizardScore, _valkyrieScore;
    private int _elfHealth, _warriorHealth, _wizardHealth, _valkyrieHealth;
    public int _elfKeys, _elfPotions, _warriorKeys, _warriorPotions, _wizardKeys, _wizardPotions, _valkyrieKeys, _valkyriePotions;
    [SerializeField] private TMP_Text _elfScoreText, _warriorScoreText, _wizardScoreText, _valkyrieScoreText;
    [SerializeField] private TMP_Text _elfHealthText, _warriorHealthText, _wizardHealthText, _valkyrieHealthText;
    [SerializeField] private TMP_Text _elfKeysText, _elfPotionsText, _warriorKeysText, _warriorPotionsText, _wizardKeysText, _wizardPotionsText, _valkyrieKeysText, _valkyriePotionsText;
    [SerializeField] private GameObject _elfJoinText, _warriorJoinText, _wizardJoinText, _valkyrieJoinText;

    //These variables manage when players join and choose their character so that they can be read by all players and add their SO.
    public bool elfJoined;
    public bool warriorJoined;
    public bool wizardJoined;
    public bool valkyrieJoined;
    public PlayerSO[] playerClasses;

    //load next level
    public void LoadNextLevel()
    {

    }
    public void AddScore(int scoreAdd, int characterIndex)
    {
        if(characterIndex == 1)
        {
            _elfScore += scoreAdd;
        }
        if(characterIndex == 2)
        {
            _warriorScore += scoreAdd;
        }
        if(characterIndex == 3)
        {
            _wizardScore += scoreAdd;
        }
        if(characterIndex == 4)
        {
            _valkyrieScore += scoreAdd;
        }
    }
    private void Update()
    {
        UpdateText();
    }
    public void UpdateText()
    {
        UpdateElfText();
        UpdateWarriorText();
        UpdateWizardText();
        UpdateValkyrieText();
    }
    public void UpdateElfText()
    {
        _elfKeysText.text = null;
        _elfPotionsText.text = null;
        _elfScoreText.text = _elfScore.ToString();
        _elfHealthText.text = _elfHealth.ToString();
        for (int i = 0; i < _elfKeys; i++)
        {
            string tempText;
            tempText = _elfKeysText.text;
            _elfKeysText.text = tempText + "‡ ";
        }
        for (int i = 0; i < _elfPotions; i++)
        {
            string tempText;
            tempText = _elfPotionsText.text;
            _elfPotionsText.text = tempText + "•  ";
        }
    }
    public void ElfJoined()
    {
        _elfJoinText.SetActive(false);
    }
    public void UpdateWarriorText()
    {
        _warriorKeysText.text = null;
        _warriorPotionsText.text = null;
        _warriorScoreText.text = _warriorScore.ToString();
        _warriorHealthText.text = _warriorHealth.ToString();
        for (int i = 0; i < _warriorKeys; i++)
        {
            string tempText;
            tempText = _warriorKeysText.text;
            _warriorKeysText.text = tempText + "‡ ";
        }
        for (int i = 0; i < _warriorPotions; i++)
        {
            string tempText;
            tempText = _warriorPotionsText.text;
            _warriorPotionsText.text = tempText + "•  ";
        }
    }
    public void WarriorJoined()
    {
        _warriorJoinText.SetActive(false);
    }
    public void UpdateWizardText()
    {
        _wizardKeysText.text = null;
        _wizardPotionsText.text = null;
        _wizardScoreText.text = _wizardScore.ToString();
        _wizardHealthText.text = _wizardHealth.ToString();
        for (int i = 0; i < _wizardKeys; i++)
        {
            string tempText;
            tempText = _wizardKeysText.text;
            _wizardKeysText.text = tempText + "‡ ";
        }
        for (int i = 0; i < _wizardPotions; i++)
        {
            string tempText;
            tempText = _wizardPotionsText.text;
            _wizardPotionsText.text = tempText + "•  ";
        }
    }
    public void WizardJoined()
    {
        _wizardJoinText.SetActive(false);
    }
    public void UpdateValkyrieText()
    {
        _valkyrieKeysText.text = null;
        _valkyriePotionsText.text = null;
        _valkyrieScoreText.text = _valkyrieScore.ToString();
        _valkyrieHealthText.text = _valkyrieHealth.ToString();
        for (int i = 0; i < _valkyrieKeys; i++)
        {
            string tempText;
            tempText = _valkyrieKeysText.text;
            _valkyrieKeysText.text = tempText + "‡ ";
        }
        for (int i = 0; i < _valkyriePotions; i++)
        {
            string tempText;
            tempText = _valkyriePotionsText.text;
            _valkyriePotionsText.text = tempText + "•  ";
        }
    }
    public void ValkyrieJoined()
    {
        _valkyrieJoinText.SetActive(false);
    }
}
