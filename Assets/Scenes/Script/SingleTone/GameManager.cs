using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
   [SerializeField]private bool _isPlaying = false;
    
   public bool isPlaying { get { return _isPlaying; } }
    
    public void ChangeGameState()
    {
        _isPlaying = !_isPlaying;
    }
    
}
