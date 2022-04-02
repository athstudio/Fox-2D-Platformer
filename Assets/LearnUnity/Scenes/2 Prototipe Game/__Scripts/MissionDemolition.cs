using UnityEngine;
using UnityEngine.UI;

    public enum GameMode 
    {
        Idle,
        Playing,
        LevelEnd
    }

public class MissionDemolition : MonoBehaviour
{
    public static MissionDemolition S; // скрытый объект-одиночка

    [Header("Set in Inspector")] 
    public Text uitLevel; // Ссылка на объект UIText_Level
    public Text uitShots; // Ссылка на объект UIText_Shots
    public Text uitButton; // Ссылка на дочерний объект Text в UIButton_View
    public Vector3 castlePos; // Местоположение замка
    public GameObject[] castles; // Массив замков

    [Header("Set Dynamically")] 
    public int level; // Текущий уровень
    public int levelMax; // Количество уровней
    public int shotsTaken;
    public GameObject castle; //Текущий замок
    public GameMode mode = GameMode.Idle;
    public string showing = "Show Slingshot"; // Режим ФолловКам


    void Start()
    {
        S = this; // Определить объект-одиночку
        level = 0;
        levelMax = castles.Length;
        StartLevel();
    }

    private void StartLevel()
    {
        // Уничтожить прежний замок, если он существует
        if (castle != null)
        {
            Destroy(castle);
        }
        // Уничтожить прежние снаряды, если они существуют
        GameObject[] gos = GameObject.FindGameObjectsWithTag("Projectile");
        foreach (GameObject pTemp in gos)
        {
            Destroy(pTemp);
        }
        // Создать новый замок
        castle = Instantiate<GameObject>(castles[level]);
        castle.transform.position = castlePos;
        shotsTaken = 0;
        
        // Переустановить камеру в начальную позицию
        SwitchView("Show Both");
        ProgectileLine.s.Clear();
        
        // Сбросить цель
        Goal.goalMet = false;

        UpdateGUI();

        mode = GameMode.Playing;
    }
    
    private void UpdateGUI()
    {
        uitLevel.text = "Level: " + (level + 1) + "+levelMAx";
        uitShots.text = "Shots " + shotsTaken;
    }

    private void Update()
    {
        UpdateGUI();
        
        // Проверить завершение уровня
        if ((mode != GameMode.Playing) || !Goal.goalMet) return;
        // Изменить режим,чтобы прекратить проверку завершения уровня
        mode = GameMode.LevelEnd;
        // Уменьшить масштаб
        SwitchView("Show Both");
        // Начать новый уровень через 2 секунды
        Invoke("NextLevel", 2f);
    }

    public  void NextLevel()
    {
        level++;
        if (level == levelMax)
        {
            level = 0;
        }
        StartLevel();
    }

    public void SwitchView(string eView = "")
    {
        if (eView == "")
        {
            eView = uitButton.text;
        }

        showing = eView;
        switch (showing)
        {
            case "Show Slingshot":
                FollowCam.poi = null;
                uitButton.text = "Show Castle";
                break;
            case "Show Castle":
                FollowCam.poi = S.castle;
                uitButton.text = "Show Both";
                break;
            case "Show Both":
                FollowCam.poi = GameObject.Find("ViewBoth");
                uitButton.text = "Show Slingshot";
                break;
        }
    }

    public static void ShotFired()
    {
        // Статический метод, позволяющий из любого кода увеличить shotsTaken
        S.shotsTaken++;
    }
}