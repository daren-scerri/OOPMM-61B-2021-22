using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class GameData : MonoBehaviour
{
    // Start is called before the first frame update
    private static int _score;
    private static int _lives;
    private static int _hscore;

    public static int GameScore
    {
        get { return _score; }
        set { _score = value; }
    }

    public static int Lives
    {
        get { return _lives; }
        set { _lives = value; }
    }

    public static int HighScore
    {
        get { return _hscore; }
        set { _hscore = value; }
    }


}
