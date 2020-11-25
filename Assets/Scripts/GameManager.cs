using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    #region time_between_spawns_and_reload_cannon_speed
    public float timeToSpawnCube = 2f;
    public float timeToSpawnSphere = 2f;
    public float timeToSpawnCone = 4f;
    public float leftCannonReloadSpeed = 0.5f;
    public float rightCannonReloadSpeed = 0.8f;
    #endregion

    #region ui_component_to_change_value_of_speed
    public Slider timeToSpawnCubeSlider;
    public Slider timeToSpawnSphereSlider;
    public Slider timeToSpawnConeSlider;
    public Text score;
    public Text maxScoreByDie;
    public GameObject settingsMenu;
    public GameObject GameOverMenu;
    public GameObject scoreItem;
    public Slider leftCannonReloadSpeedSlider;
    public Slider rightCannonReloadSpeedSlider;
    #endregion

    public int live = 20; // Количество возможных пропусков фигур
    public static GameManager instance = null; // Экземпляр объекта
    public GameObject person; // персонаж, с анимацией
    public bool isCanPlay = false; 
    
    void Start()
    {
        if (instance == null)
            instance = this;
        else if (instance == this)
            Destroy(gameObject);

        DontDestroyOnLoad(gameObject);
        InitializeManager();

        leftCannonReloadSpeedSlider.value = leftCannonReloadSpeed;
        rightCannonReloadSpeedSlider.value = rightCannonReloadSpeed;
        timeToSpawnCubeSlider.value = timeToSpawnCube;
        timeToSpawnSphereSlider.value = timeToSpawnSphere;
        timeToSpawnConeSlider.value = timeToSpawnCone;
    }
    private void InitializeManager()
    {
    }
    public void setTimeToSpawnCube()
    {
        timeToSpawnCube = timeToSpawnCubeSlider.value;
    }
    public void setTimeToSpawnSphere()
    {
        timeToSpawnSphere = timeToSpawnSphereSlider.value;
    }
    public void setTimeToSpawnCone()
    {
        timeToSpawnCone = timeToSpawnConeSlider.value;
    }
    public void StartPlay() // запуск 
    {
        isCanPlay = true;
        settingsMenu.SetActive(false);
        scoreItem.SetActive(true);
    }
    public void setLeftCannonReloadSpeed()
    {
        leftCannonReloadSpeed = leftCannonReloadSpeedSlider.value;
    }
    public void setRightCannonReloadSpeed()
    {
        rightCannonReloadSpeed = rightCannonReloadSpeedSlider.value;
    }
    public void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+0);
        Destroy(gameObject);
    }
}
