using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameController : MonoBehaviour
{
    //Global Variables within our script
    public int whoseTurn; // 0 = x and 1 = 0
    public int turnCounter; //Counts the number of turns played
    public GameObject[] turnIcons; //Displays whose turn it is
    public Sprite[] playerIcons; //0 = X icon and 1 = O icon
    public Button[] TTTspaces; //Playable spaces for our game
    public int[] markedSpaces; //ID's which space was marked by which player
    public TextMeshProUGUI winnerText; //Holds the text component of the winner text
    public GameObject[] winningLines; //Holds all the different lines for showing there is a winner
    public GameObject winnerPanel;
    public int xPlayerScore;
    public int oPlayerScore;
    public TextMeshProUGUI xPlayerScoreText;
    public TextMeshProUGUI oPlayerScoreText;
    public AudioSource buttonclickAudio;
    public AudioSource buttonClickAudio2;
    public AudioSource winner;
    public AudioSource stalementAudio;


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

        for (int i = 0; i < TTTspaces.Length; i++)
        {
            TTTspaces[i].interactable = true;
            TTTspaces[i].GetComponent<Image>().sprite = null;
        }

        for (int i = 0; i < markedSpaces.Length; i++)
        {
            markedSpaces[i] = -100;
        }

    }

    // Update is called once per frame
    void Update()
    {   
    }

    public void TicTacToeButton(int whichNumber)
    {
        TTTspaces[whichNumber].image.sprite = playerIcons[whoseTurn];
        TTTspaces[whichNumber].interactable = false;
        
        markedSpaces[whichNumber] = whoseTurn+1; //Identifies which space has been marked by which player
        turnCounter++;
        
        if (turnCounter > 4)
        {
            bool isWinner = WinnerCheck();

            if (turnCounter == 9 && isWinner == false)
            {
                Tie();
                stalementAudio.Play();
            }

        }

        
       

        if (whoseTurn == 0)
        {
            whoseTurn = 1;
            turnIcons[0].SetActive(false);
            turnIcons[1].SetActive(true);
        }
        else
        {
            whoseTurn = 0;
            turnIcons[0].SetActive(true);
            turnIcons[1].SetActive(false);
        }
    }


    bool WinnerCheck()
    {
        //Straight Line horziontal
        int s1 = markedSpaces[0] + markedSpaces[1] + markedSpaces[2];
        int s2 = markedSpaces[3] + markedSpaces[4] + markedSpaces[5];
        int s3 = markedSpaces[6] + markedSpaces[7] + markedSpaces[8];

        //Vertical
        int s4 = markedSpaces[0] + markedSpaces[3] + markedSpaces[6];
        int s5 = markedSpaces[1] + markedSpaces[4] + markedSpaces[7];
        int s6 = markedSpaces[2] + markedSpaces[5] + markedSpaces[8];

        //Diagonal
        int s7 = markedSpaces[0] + markedSpaces[4] + markedSpaces[8];
        int s8 = markedSpaces[2] + markedSpaces[4] + markedSpaces[6];



        var solutions = new int[] { s1, s2, s3, s4, s5, s6, s7, s8 }
;
        for (int i = 0; i < solutions.Length; i++)
        {
            if (solutions[i] == 3*(whoseTurn+1))
            {
                WinnerDisplay(i);
                return true;
            }
        }

        return false;
    }

    void WinnerDisplay(int indexIn)
    {

        winnerPanel.gameObject.SetActive(true);
       // winnerText.gameObject.SetActive(true);
      
        

        if(whoseTurn == 0)
        {
            xPlayerScore++;
            xPlayerScoreText.text = xPlayerScore.ToString();
            winnerText.text = "Player X Wins";
            winner.Play();
        }
        else if(whoseTurn == 1)
        {
            oPlayerScore++;
            oPlayerScoreText.text = oPlayerScore.ToString();
            winnerText.text = "Player O Wins!";
            winner.Play();
        }

        winningLines[indexIn].SetActive(true);

    }


    public void Rematch()
    {
        GameSetup();

        for(int i = 0; i < winningLines.Length; i++)
        {
            winningLines[i].SetActive(false);
        }
        winnerPanel.SetActive(false);
    }

    public void Restart()
    {
        Rematch();
        xPlayerScore = 0;
        oPlayerScore = 0;

        xPlayerScoreText.text = "0";
        oPlayerScoreText.text = "0";
  
    }

    void Tie()
    {
        winnerPanel.SetActive(true);
        winnerText.text = "TIE!!!";
    }


    public void PlayButtonClick()
    {
        buttonclickAudio.Play();
    }

    public void RestartAndRematchClick()
    {
        buttonClickAudio2.Play();

    }


    

}
