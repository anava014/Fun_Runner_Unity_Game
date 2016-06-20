using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class DisplayHighScore : MonoBehaviour {
    private const int length = 30;

    static void position(List<int> l, int i)
    {
        for(int j = 4; j > i + 1; j--)
        {
            l[j] = l[j - 1];
        }
    }

    static void Clear()
    {
        for(int i = 0; i < length; i++)
            PlayerPrefs.DeleteKey("HighScore" + i + "score");
    }

    public static void insert_Score()
    {
        List<int> HighScores = new List<int>();
        int score = DisplayTime.playtime;
        int start = 0;
        string level = ChangeScene.prevScene;

        if(level == "levelx_britt")
            start = 0;
        else if(level == "levelx_justin")
            start = 5;
        else if(level == "levelx")
            start = 10;
        else if(level == "level_david")
            start = 15;
        else if(level == "level_Falcon")
            start = 20;
        else if(level == "level_endless")
            start = 25;

        for(int i = 0; i < 5; i++)
        {
            int temp = PlayerPrefs.GetInt("HighScore" + (i + start) + "score");
            HighScores.Add(temp);
        }

        if(level != "level_endless")
        {
            for(int i = 0; i < 5; i++)
            {
                if(HighScores[i] == 0 || HighScores[i] > score)
                {
                    position(HighScores, i);
                    HighScores[i] = score;
                    break;
                }
            }
        }
        else
        {
            if(HighScores[4] < score)
            {
                HighScores[4] = score;
                HighScores.Sort(
                    delegate(int x, int y)
                    {
                        return x.CompareTo(y);
                    }
                );
            }
        }

        for(int i = 0; i < 5; i++)
        {
            PlayerPrefs.SetInt("HighScore" + (i + start) + "score", HighScores[i]);
        }        
    }

    public static string format(int number)
    {
        int sec = 0;
        int min = 0;
        int millisec = 0;
        int temp = 0;

        if(number != 0)
        {
            temp = number;
            millisec = (temp % 1000) / 10;
            sec = (temp / 1000) % 60;
            min = (temp / 60000) % 60;
        }
        string display = string.Format("{0:00}:{1:00}:{2:00}", min, sec, millisec);
        return display;
    }

    public static string return_highscore()
    {
        int start = 0;

        if(ChangeScene.prevScene == "levelx_britt")
            start = 0;
        else if(ChangeScene.prevScene == "levelx_justin")
            start = 5;
        else if(ChangeScene.prevScene == "levelx")
            start = 10;
        else if(ChangeScene.prevScene == "level_david")
            start = 15;
        else if(ChangeScene.prevScene == "level_Falcon")
            start = 20;
        else if(ChangeScene.prevScene == "level_endless")
            start = 25;

        return format(PlayerPrefs.GetInt("HighScore" + start + "score"));
    }

    void OnApplicationQuit()
    {
        PlayerPrefs.Save();
    }

    void OnGUI()
    {
        string display1 = "   Level 1: \n";
        string display2 = "   Level 2: \n";
        string display3 = "   Level 3: \n";
        string display4 = "   Level 4: \n";
        string display5 = "   Level 5: \n";
        string endless_display = "  Endless: \n";

        for (int i = 0; i < length; i++)
        {
            if(i < 5)
            {
                
                display1 = display1 + (i + 1) + ": " + format(PlayerPrefs.GetInt("HighScore" + i + "score")) + "\n";
            }
            else if(i >= 5 && i < 10)
            {
                
                display2 = display2 + (i + 1 - 5) + ": " + format(PlayerPrefs.GetInt("HighScore" + i + "score")) + "\n";
            }
            else if(i >= 10 && i < 15)
            {
                
                display3 = display3 + (i + 1 - 10) + ": " + format(PlayerPrefs.GetInt("HighScore" + i + "score")) + "\n";
            }
            else if(i >= 15 && i < 20)
            {
                
                display4 = display4 + (i + 1 - 15) + ": " + format(PlayerPrefs.GetInt("HighScore" + i + "score")) + "\n";
            }
            else if(i >= 20 && i < 25)
            {
                
                display5 = display5 + (i + 1 - 20) + ": " + format(PlayerPrefs.GetInt("HighScore" + i + "score")) + "\n";
            }
            else if(i >= 25 && i < 30)
            {
                
                endless_display = endless_display + (i + 1 - 25) + ": " + format(PlayerPrefs.GetInt("HighScore" + i + "score")) + "\n";
            }
        }

        GUI.color = Color.yellow;
        GUI.skin.label.fontSize = 18;
        GUI.Label(new Rect(115, 120, 400, 500), display1);
        GUI.Label(new Rect(227, 120, 400, 500), display2);
        GUI.Label(new Rect(339, 120, 400, 500), display3);
        GUI.Label(new Rect(451, 120, 400, 500), display4);
        GUI.Label(new Rect(563, 120, 400, 500), display5);
        GUI.Label(new Rect(675, 120, 400, 500), endless_display);
    }
}
