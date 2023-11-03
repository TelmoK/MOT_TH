using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class GameManager : MonoBehaviour
{
    #region references
    private InputManager _inputManager;
    private GameManager _gameManager;
    private UIManager _UIManager;
    #endregion

    #region methods
    /// <summary>
    /// Public method used to inform GameManager that the target has been reached
    /// </summary>
    public void OnTargetReached()
    {
        _gameManager.GameFinishes();
    }
    /// <summary>
    /// Public method used to inform GameManager that the player has clicked Start button
    /// </summary>
    public void OnPressedStart()
    {
        _gameManager.GameStarts();
    }
    /// <summary>
    /// GameManager executes this method to set required elements for Start Menu
    /// </summary>
    private void StartMenu()
    {
        _inputManager.enabled = false;
        _UIManager.SetMainMenu(true);
    }
    /// <summary>
    /// GameManager executes this method to set required elements to start the Game
    /// </summary>
    private void GameStarts()
    {
        _inputManager.enabled = true;
        _UIManager.SetMainMenu(false);
    }
    /// <summary>
    /// GameManager executes this method to set the required elements to finish the Game
    /// </summary>
    private void GameFinishes()
    {
        _inputManager.enabled = false;
        _UIManager.SetVictoryScreen(true);
    }
    #endregion

    /// <summary>
    /// Initial setup of references and call to StartMenu
    /// </summary>
    void Start()
    {
        _UIManager = GetComponent<UIManager>();
        _inputManager = GetComponent<InputManager>();
        _gameManager = GetComponent<GameManager>();

        _UIManager.SetVictoryScreen(false);
        StartMenu();
    }
}
