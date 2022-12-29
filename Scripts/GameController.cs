using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public int whoseTurn; // 0 = x and 1 = 0
    public int turnCounter; //Counts the number of turns played
    public GameObject[] turnIcons; //Displays whose turn it is
    public Sprite[] playerIcons; //0 = X icon and 1 = y icon
    public Button[] TTTspaces; //Playable spaces for our game
 


    // Start is called before the first frame update
    void Start()
    {
        GameSetup();
    }

    void GameSetup()
    {
        whoseTurn = 0; //X goes first
        turnCounter = 0; //
        turnIcons[0].SetActive(true);
        turnIcons[1].SetActive(false);

        for (int i = 0; i < TTTspaces.Length;i++)
        {
            TTTspaces[i].interactable = true;
            TTTspaces[i].GetComponent<Image>().sprite = null;
        }
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}


