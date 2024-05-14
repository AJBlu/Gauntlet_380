using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : Singleton<GameManager>
{
    //UI elemenets that are needed for the game with each character having certain things tracked.
    private int _level;
    [SerializeField]private GameObject playersGO;
    private int _elfScore, _warriorScore, _wizardScore, _valkyrieScore;
    private int _elfHealth, _warriorHealth, _wizardHealth, _valkyrieHealth;
    public int _elfKeys, _elfPotions, _warriorKeys, _warriorPotions, _wizardKeys, _wizardPotions, _valkyrieKeys, _valkyriePotions;
    [SerializeField] private GameObject _currentLevel;
    [SerializeField] private TMP_Text _levelText;
    [SerializeField] private TMP_Text _promptText;
    [SerializeField] private TMP_Text _elfScoreText, _warriorScoreText, _wizardScoreText, _valkyrieScoreText;
    [SerializeField] private TMP_Text _elfHealthText, _warriorHealthText, _wizardHealthText, _valkyrieHealthText;
    [SerializeField] private TMP_Text _elfTimerText, _warriorTimerText, _wizardTimerText, _valkyrieTimerText;
    [SerializeField] private TMP_Text _elfKeysText, _elfPotionsText, _warriorKeysText, _warriorPotionsText, _wizardKeysText, _wizardPotionsText, _valkyrieKeysText, _valkyriePotionsText;
    [SerializeField] private GameObject _gameOverGO, _elfJoinText, _warriorJoinText, _wizardJoinText, _valkyrieJoinText, _promptHolder, _elfTimerGO, _warriorTimerGO, _wizardTimerGO, _valkyrieTimerGO;

    //These variables manage when players join and choose their character so that they can be read by all players and add their SO.
    public bool isGameOver;
    public bool elfJoined;
    public bool warriorJoined;
    public bool wizardJoined;
    public bool valkyrieJoined;
    public bool hasGameStarted = false;
    public bool elfNotPlaying = true;
    public bool warriorNotPlaying = true;
    public bool wizardNotPlaying = true;
    public bool valkyrieNotPlaying = true;
    public PlayerSO[] playerClasses;
    public GameObject[] levels;
    private void Update()
    {
        UpdateText();

        if(hasGameStarted)
        {
            if(elfNotPlaying && warriorNotPlaying && wizardNotPlaying && valkyrieNotPlaying)
            {
                Debug.Log("Game is Over");
                GameOver();
            }
        }
    }
    //This is for testing levels loading ONLY!!!!
    /*private void OnGUI()
    {
        if(GUILayout.Button("Load Next"))
        {
            LoadNextLevel();
        }
    }*/
    public void GameOver()
    {
        Time.timeScale = 0f;
        _gameOverGO.SetActive(true);
        hasGameStarted = false;
        isGameOver = true;
    }
    public void ResetGame()
    {
        _gameOverGO.SetActive(false);
        isGameOver = false;
        //Only use if you have levels in your Levels Array under GameManager.
        //LoadLevel1();
        Time.timeScale = 1f;
    }
    public void LoadLevel1()
    {
        _level = 1000;
        LoadNextLevel();
    }
    //load next level
    public void LoadNextLevel()
    {
        playersGO.transform.position = new Vector3(0, 1.5f, 0);
        foreach (PlayerController player in FindObjectsOfType<PlayerController>())
        {
            player.transform.position = new Vector3(0, 1.5f, 0);
        }
        Destroy(_currentLevel);
        _level++;
        if(_level > levels.Length - 1)
        {
            _level = 0;
        }
        Debug.Log(_level);
        _currentLevel = Instantiate(levels[_level].gameObject);
        _currentLevel.transform.position = Vector3.zero;
    }
    //Call whenever score would be changed (i.e. when a enemy is defeated, treasure is grabbed, potion, etc.) 
    public void AddScore(int scoreAdd, Hero heroEnum)
    {
        if(heroEnum == Hero.ELF)
        {
            _elfScore += scoreAdd;
        }
        if(heroEnum == Hero.WARRIOR)
        {
            _warriorScore += scoreAdd;
        }
        if(heroEnum == Hero.MAGE)
        {
            _wizardScore += scoreAdd;
        }
        if(heroEnum == Hero.VALKYRIE)
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
    public void UpdateHealth(int health, Hero heroEnum)
    {
        if (heroEnum == Hero.ELF)
        {
            _elfHealth = health;
        }
        if (heroEnum == Hero.WARRIOR)
        {
            _warriorHealth = health;
        }
        if (heroEnum == Hero.MAGE)
        {
            _wizardHealth = health;
        }
        if (heroEnum == Hero.VALKYRIE)
        {
            _valkyrieHealth = health;
        }
    }
    //Call whenever the inventory would changed
    public void UpdateInventory(int potions, int keys, Hero heroEnum)
    {
        if (heroEnum == Hero.ELF)
        {
            _elfKeys = keys;
            _elfPotions = potions;
        }
        if (heroEnum == Hero.WARRIOR)
        {
            _warriorKeys = keys;
            _warriorPotions = potions;
        }
        if (heroEnum == Hero.MAGE)
        {
            _wizardKeys = keys;
            _wizardPotions = potions;
        }
        if (heroEnum == Hero.VALKYRIE)
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
        _elfKeysText.enabled = true;
        _elfPotionsText.enabled = true;
        _elfTimerGO.SetActive(false);
    }
    public void ElfDeadPrompt()
    {
        _elfJoinText.SetActive(true);
        _elfKeysText.enabled = false;
        _elfPotionsText.enabled = false;
        _elfTimerGO.SetActive(true);
    }
    public void ElfHasReset()
    {
        _elfTimerGO.SetActive(false);
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
        _warriorKeysText.enabled = true;
        _warriorPotionsText.enabled = true;
        _warriorTimerGO.SetActive(false);
    }
    public void WarriorDeadPrompt()
    {
        _warriorJoinText.SetActive(true);
        _warriorKeysText.enabled = false;
        _warriorPotionsText.enabled = false;
        _warriorTimerGO.SetActive(true);
    }
    public void WarriorHasReset()
    {
        _warriorTimerGO.SetActive(false);
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
        _wizardKeysText.enabled = true;
        _wizardPotionsText.enabled = true;
        _wizardTimerGO.SetActive(false);
    }
    public void WizardDeadPrompt()
    {
        _wizardJoinText.SetActive(true);
        _wizardKeysText.enabled = false;
        _wizardPotionsText.enabled = false;
        _wizardTimerGO.SetActive(true);
    }
    public void WizardHasReset()
    {
        _wizardTimerGO.SetActive(false);
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
        _valkyrieKeysText.enabled = true;
        _valkyriePotionsText.enabled = true;
        _valkyrieTimerGO.SetActive(false);
    }
    public void ValkyrieDeadPrompt()
    {
        _valkyrieJoinText.SetActive(true);
        _valkyrieKeysText.enabled = false;
        _valkyriePotionsText.enabled = false;
        _valkyrieTimerGO.SetActive(true);
    }
    public void ValkyrieHasReset()
    {
        _valkyrieTimerGO.SetActive(false);
    }
    public void TimerTextUpdate(float timerValue, Hero heroEnum)
    {
        float seconds = Mathf.RoundToInt(timerValue);
        if(heroEnum == Hero.ELF)
        {
            _elfTimerText.text = seconds.ToString();
        }
        if (heroEnum == Hero.WARRIOR)
        {
            _warriorTimerText.text = seconds.ToString();
        }
        if (heroEnum == Hero.MAGE)
        {
            _wizardTimerText.text = seconds.ToString();
        }
        if (heroEnum == Hero.VALKYRIE)
        {
            _valkyrieTimerText.text = seconds.ToString();
        }
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
