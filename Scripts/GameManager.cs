using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Advertisements;

public class GameManager : MonoBehaviour, IUnityAdsInitializationListener
{
    public Player player;
    public Text scoreText;

    public Text highscoreText;
    public GameObject playButton;
    public GameObject gameOver;
    public GameObject PauseButton;
    public GameObject Highscore;

    public GameObject Score;
    private int score;
    private int highscore;

    public AudioSource[] sounds;
    public AudioSource sound1;
    public AudioSource sound2;
    public AudioSource sound3;

    public GameObject Medal;
    public GameObject Medal2;
    public GameObject Medal3;
    public GameObject MedalBlank;

    public GameObject ADButton;
    public GameObject ContinueButton;

    [SerializeField] string _androidGameId;
    [SerializeField] string _iOSGameId;
    [SerializeField] bool _testMode = true;
    private string _gameId;
    [SerializeField] RewardedAdsButton rewardedAdsButton;
 
    public void InitializeAds()
    {
        _gameId = (Application.platform == RuntimePlatform.IPhonePlayer)
            ? _iOSGameId
            : _androidGameId;
        Advertisement.Initialize(_gameId, _testMode, this);
    }
 
    public void OnInitializationComplete()
    {
        Debug.Log("Unity Ads initialization complete.");
        rewardedAdsButton.LoadAd();
    }
 
    public void OnInitializationFailed(UnityAdsInitializationError error, string message)
    {
        Debug.Log($"Unity Ads Initialization Failed: {error.ToString()} - {message}");
    }
    private void Awake()
    {
        PauseButton.SetActive(false);
        Application.targetFrameRate = 60;
        //AudioSource source = GetComponent<AudioSource>();
        //source.Play();
        sounds = GetComponents<AudioSource>();
        sound1 = sounds[0];
        sound2 = sounds[1];
        sound3 = sounds[2];
        sound2.Play();
        Pause();
    }

    public void Play()
    {
        sound2.Play();
        score = 0;
        highscore = PlayerPrefs.GetInt("highscore", 0);
        scoreText.text = score.ToString();
        highscoreText.text = "HIGHSCORE: " + highscore.ToString();
        playButton.SetActive(false);
        gameOver.SetActive(false);
        PauseButton.SetActive(true);
        Highscore.SetActive(true);
        Score.SetActive(true);
        Time.timeScale = 1f;
        player.enabled = true;
        Medal.SetActive(false);
        Medal2.SetActive(false);
        Medal3.SetActive(false);
        MedalBlank.SetActive(false);
        ADButton.SetActive(false);
        ContinueButton.SetActive(false);

        Obstacle[] obstacles = FindObjectsOfType<Obstacle>();

        for (int i = 0; i < obstacles.Length; i++)
        {
            Destroy(obstacles[i].gameObject);
        }
        

    }

    public void Continue()
    {
        sound2.Play();
        highscore = PlayerPrefs.GetInt("highscore", 0);
        scoreText.text = score.ToString();
        highscoreText.text = "HIGHSCORE: " + highscore.ToString();
        playButton.SetActive(false);
        gameOver.SetActive(false);
        PauseButton.SetActive(true);
        Highscore.SetActive(true);
        Score.SetActive(true);
        Time.timeScale = 1f;
        player.enabled = true;
        Medal.SetActive(false);
        Medal2.SetActive(false);
        Medal3.SetActive(false);
        MedalBlank.SetActive(false);
        ADButton.SetActive(false);
        ContinueButton.SetActive(false);

        Obstacle[] obstacles = FindObjectsOfType<Obstacle>();

        for (int i = 0; i < obstacles.Length; i++)
        {
            Destroy(obstacles[i].gameObject);
        }
        

    }

    public void Pause()
    {
        Time.timeScale = 0f; // time doesnt update
        player.enabled = false; // disable player
    }

    public void GameOver()
    {
        
        sound2.Pause();
        sound3.Play();
        ContinueButton.SetActive(false);
        InitializeAds();
        ADButton.SetActive(true);
        gameOver.SetActive(true);
        playButton.SetActive(true);
        PauseButton.SetActive(false);
        
        
        

        if (highscore >= 100)
        {
            Medal3.SetActive(true);
        }
        else if (highscore >= 50)
        {
            Medal2.SetActive(true);
        }
        else if (highscore >= 25)
        {
            Medal.SetActive(true);
        }
        else
        {
            MedalBlank.SetActive(true);
        }
        
        Pause();
    }
    

    public void IncreaseScore()
    {
        score++;
        scoreText.text = score.ToString();
        if (highscore < score)
        {
            PlayerPrefs.SetInt("highscore", score);
        }
        sound1.Play();
        
        
    }


}
