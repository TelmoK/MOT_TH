using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class UIManager : MonoBehaviour
{
    #region references
    /// <summary>
    /// Reference to Main Menu
    /// (Established in editor)
    /// </summary>
    [SerializeField]
    private GameObject _mainMenu;
    /// <summary>
    /// Reference to Victory Screen
    /// (Established in editor)
    /// </summary>
    [SerializeField]
    private GameObject _victoryScreen;
    /// <summary>
    /// Reference to GameManager
    /// </summary>
    private GameManager _gameManager;
    #endregion
    #region methods
    /// <summary>
    /// Called when the player presses start button.
    /// Needs to inform GameManager that the button has been pressed.
    /// </summary>
    public void OnPressStart()
    {
        //TODO
    }
    /// <summary>
    /// UI Manager provides this method to allow managament of Main Menu
    /// </summary>
    /// <param name="newState"></param>
    public void SetMainMenu(bool newState)
    {
        //TODO
    }
    /// <summary>
    /// UI Manager provides this methif to allow managament of Victory Screen
    /// </summary>
    /// <param name="newState"></param>
    public void SetVictoryScreen(bool newState)
    {
        //TODO
    }
    #endregion

    /// <summary>
    /// Set reference to Game Manager
    /// </summary>
    void Start()
    {
        //TODO

    }
}
