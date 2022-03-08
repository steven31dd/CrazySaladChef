using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;


//Singleton
public class GameManager : MonoBehaviour
{
    private static GameManager _instance;
    public static GameManager Instance { get { return _instance; } }

    [Header("Players")]
    [SerializeField] GameObject player_one_prefab;
    [SerializeField] GameObject player_two_prefab;

    //Events for Listeners
    [Header("Events")]
    [SerializeField] EventObject gameReady;


    Transform playerOneStart;
    Transform playerTwoStart;

    GameObject plyOneUI;
    GameObject plyTwoUI;

    GameObject plyOneScorePanel;
    GameObject plyTwoScorePanel;
    GameObject EndPanel;

    private int plyOnePoints = 0;
    private int plyTwoPoints = 0;

    //Set is ADDITIVE
    public int PlayerOnePoints { get { return plyOnePoints; } set { 
            plyOnePoints += value;
            plyOneScorePanel.transform.GetChild(0).GetComponent<TMP_Text>().text = plyOnePoints.ToString();
        } }
    public int PlayerTwoPoints { get { return plyTwoPoints; } set {
            plyTwoPoints += value;
            plyTwoScorePanel.transform.GetChild(0).GetComponent<TMP_Text>().text = plyTwoPoints.ToString();
        } }

    private int _numPlayers = 0;
    public int NumPlayers { get { return _numPlayers; } 
        set {


            if(value <= 0)
            {
                _numPlayers = 1;
                return;
            }

            if(value >= 3)
            {
                _numPlayers = 2;
                return;
            }

            _numPlayers = value;

        } }

    // Start is called before the first frame update
    private void Awake()
    {
        if(_instance == null)
        {
           _instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void StartGame(int NumPlayers)
    {
        _numPlayers = NumPlayers;

        SceneManager.LoadScene(1);


        StartCoroutine(waitForSceneLoad(1));
        
    }

    IEnumerator waitForSceneLoad(int sceneNumber)
    {
        while (SceneManager.GetActiveScene().buildIndex != sceneNumber)
        {
            yield return null;
        }

        // Do anything after proper scene has been loaded
        if (SceneManager.GetActiveScene().buildIndex == sceneNumber)
        {
            //Load Players in
            if (_numPlayers == 1)
            {
                //Find Start Position
                playerOneStart = GameObject.Find("SpawnPoint_One").transform;
                //Spawn Player
                GameObject newPlayer = Instantiate(player_one_prefab, playerOneStart.position, Quaternion.identity);
                //properly set name so camera can find
                newPlayer.name = "Player1";

                plyTwoUI = GameObject.Find("PlayerTwoInventory");
                plyTwoUI.SetActive(false);
            }
            else
            {
                //Find Start Positions
                playerOneStart = GameObject.Find("SpawnPoint_One").transform;
                playerTwoStart = GameObject.Find("SpawnPoint_Two").transform;

                //Spawn Players
                GameObject newPlayerOne = Instantiate(player_one_prefab, playerOneStart.position, Quaternion.identity);
                GameObject newPlayerTwo = Instantiate(player_two_prefab, playerTwoStart.position, Quaternion.identity);

                //properly set name so camera can find
                newPlayerOne.name = "Player1";
                newPlayerTwo.name = "Player2";
            }

            //Trigger Event to ready game and camera
            gameReady.TriggerEvent();

            EndPanel = GameObject.FindGameObjectWithTag("End");
            EndPanel.SetActive(false);

            plyOneScorePanel = GameObject.FindGameObjectWithTag("PlayerOneScore");
            plyTwoScorePanel = GameObject.FindGameObjectWithTag("PlayerTwoScore");

            plyOneScorePanel.transform.GetChild(0).GetComponent<TMP_Text>().text = "0";
            plyTwoScorePanel.transform.GetChild(0).GetComponent<TMP_Text>().text = "0";
        }
    }

    public void ShowScoreAndFreezePlayers()
    {
        GameObject.Find("Player1").GetComponent<PlayerMovement>().IsWorking = true;
        GameObject.Find("Player2").GetComponent<PlayerMovement>().IsWorking = true;

        if(_numPlayers == 2)
        {
            if (plyOnePoints > plyTwoPoints)
            {
                EndPanel.transform.GetChild(0).GetComponent<TMP_Text>().text = "Player One Wins";
                EndPanel.transform.GetChild(1).GetComponent<TMP_Text>().text = "Score: " + plyOnePoints;
            }else if (plyTwoPoints > plyOnePoints)
            {
                EndPanel.transform.GetChild(0).GetComponent<TMP_Text>().text = "Player Two Wins";
                EndPanel.transform.GetChild(1).GetComponent<TMP_Text>().text = "Score: " + plyTwoPoints;
            }
            else
            {
                EndPanel.transform.GetChild(0).GetComponent<TMP_Text>().text = "DRAW!";
            }
        }
        else
        {
            EndPanel.transform.GetChild(0).GetComponent<TMP_Text>().text = "Player One Completed";
            EndPanel.transform.GetChild(1).GetComponent<TMP_Text>().text = "Score: " + plyOnePoints;

        }

        EndPanel.SetActive(true);

        Invoke("SwitchToMenu", 2.0f);
    }

    private void SwitchToMenu()
    {
        SceneManager.LoadScene(0);
    }


    void Start()
    {
        
    }

}
