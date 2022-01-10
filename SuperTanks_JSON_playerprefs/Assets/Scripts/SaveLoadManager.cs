using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveLoadManager : MonoBehaviour
{
    SerializedData myserializedData;
    public void Start()
    {
        myserializedData = new SerializedData();
    }
    public void SaveMyData()
    {
        myserializedData.ser_score = GameData.GameScore;
        myserializedData.ser_lives = GameData.Lives;
        myserializedData.ser_highscore = GameData.HighScore;

        string jsontosave = JsonUtility.ToJson(myserializedData);
        Debug.Log(jsontosave);
        PlayerPrefs.SetString("TanksData", jsontosave);

    }


    public void LoadMyData()
    {
        string loadedjson;
        if (PlayerPrefs.HasKey("TanksData"))
        {
            loadedjson = PlayerPrefs.GetString("TanksData");
            myserializedData = JsonUtility.FromJson<SerializedData>(loadedjson);
            GameData.GameScore = myserializedData.ser_score;
            GameData.Lives = myserializedData.ser_lives;
            GameData.HighScore = myserializedData.ser_highscore;
        }
    }
}
