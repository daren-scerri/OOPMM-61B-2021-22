using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

using System.Runtime.Serialization.Formatters.Binary;

public class SaveLoadManager : MonoBehaviour
{
    

    public void SaveMyData()
    {
        SerializedData myserializedData = new SerializedData();


        myserializedData.ser_score = GameData.GameScore;
        myserializedData.ser_lives = GameData.Lives;
        myserializedData.ser_highscore = GameData.HighScore;

        BinaryFormatter bf = new BinaryFormatter();

        Debug.Log(Application.persistentDataPath);
        FileStream file = File.Create(Application.persistentDataPath + "/gamedata.save");

        bf.Serialize(file, myserializedData);
        file.Close();

        Debug.Log("GAME SAVED!");



       // string jsontosave = JsonUtility.ToJson(myserializedData);
       // Debug.Log(jsontosave);
       //  PlayerPrefs.SetString("TanksData", jsontosave);

    }


    public void LoadMyData()
    {
        SerializedData myloadedData = new SerializedData();

        // string loadedjson;
        if (File.Exists(Application.persistentDataPath + "/gamedata.save") == true)
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/gamedata.save", FileMode.Open);

            myloadedData = (SerializedData)bf.Deserialize(file);
            file.Close();

            if (myloadedData != null)
            {
                GameData.GameScore = myloadedData.ser_score;
                GameData.Lives = myloadedData.ser_lives;
                GameData.HighScore = myloadedData.ser_highscore;
            }
       }
    }
}


  
         //   loadedjson = PlayerPrefs.GetString("TanksData");
         //   myserializedData = JsonUtility.FromJson<SerializedData>(loadedjson);