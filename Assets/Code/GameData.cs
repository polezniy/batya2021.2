using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GameData
{
    // Singleton
    // Следит за жизнями и доминацией игрока
    private static GameData _current;
    public int health;
    public int domination;
    public static GameData current
    {
        get
        {
            if (_current == null)
            {
                _current = new GameData();
            }
            return _current;
        }
        set
        {
            if (value != null)
            {
                _current = value;
            }
        }
    }
}
