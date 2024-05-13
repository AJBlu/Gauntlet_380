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
    [SerializeField] private TMP_Text _levelText;
    [SerializeField] private TMP_Text _promptText;
    [SerializeField] private TMP_Text _elfScoreText, _warriorScoreText, _wizardScoreText, _valkyrieScoreText;
    [SerializeField] private TMP_Text _elfHealthText, _warriorHealthText, _wizardHealthText, _valkyrieHealthText;
    [SerializeField] private TMP_Text _elfKeysText, _elfPotionsText, _warriorKeysText, _warriorPotionsText, _wizardKeysText, _wizardPotionsText, _valkyrieKeysText, _valkyriePotionsText;
    [SerializeField] private GameObject _elfJoinText, _warriorJoinText, _wizardJoinText, _valkyrieJoinText, _promptHolder;

    //These variables manage when players join and choose their character so that they can be read by all players and add their SO.
    public bool elfJoined;
    public bool warriorJoined;
    public bool wizardJoined;
    public bool valkyrieJoined;
    public PlayerSO[] playerClasses;

    private void Update()
    {
        UpdateText();
    }
    //load next level
    public void LoadNextLevel()
    {

    }
    //Call whenever score would be changed (i.e. when a enemy is defeated, treasure is grabbed, potion, etc.) 
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
    public void UpdateText()
    {
        UpdateElfText();
        UpdateWarriorText();
        UpdateWizardText();
        UpdateValkyrieText();
        UpdateLevelText();
    }
    public void PromptActivate(string promptText)
    {
        _promptHolder.SetActive(!_promptHolder.activeInHierarchy);
        _promptText.text = promptText;
    }
    //Call to update health from other scripts using the character index to check which health to update
    public void UpdateHealth(int health, int characterIndex)
    {
        if (characterIndex == 1)
        {
            _elfHealth = health;
        }
        if (characterIndex == 2)
        {
            _warriorHealth = health;
        }
        if (characterIndex == 3)
        {
            _wizardHealth = health;
        }
        if (characterIndex == 4)
        {
            _valkyrieHealth = health;
        }
    }
    //Call whenever the inventory would changed
    public void UpdateInventory(int potions, int keys, int characterIndex)
    {
        if (characterIndex == 1)
        {
            _elfKeys = keys;
            _elfPotions = potions;
        }
        if (characterIndex == 2)
        {
            _warriorKeys = keys;
            _warriorPotions = potions;
        }
        if (characterIndex == 3)
        {
            _wizardKeys = keys;
            _wizardPotions = potions;
        }
        if (characterIndex == 4)
        {
            _valkyrieKeys = keys;
            _valkyriePotions = potions;
        }
    }
    public void UpdateLevelText()
    {
        _levelText.text = _level.ToString();
    }
    //Text updates for each character and way to disable text telling you how to join
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
    public IEnumerator PromptPopUp(string prompt)
    {
        GameManager.Instance.PromptActivate(prompt);
        Time.timeScale = 0f;
        yield return new WaitForSecondsRealtime(1.5f);
        Time.timeScale = 1f;
        prompt = "";
        GameManager.Instance.PromptActivate(prompt);
    }    
}
