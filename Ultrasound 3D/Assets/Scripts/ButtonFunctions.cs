using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ButtonFunctions : MonoBehaviour
{
    [Header("Components")]
    [SerializeField] ImageLoader imageLoader;
    [SerializeField] Camera sceneCamera;

    [Header("Global Variables")]
    [SerializeField] int cameraMaxSize = 70;
    [SerializeField] int cameraMinSize = 50;

    [Header("UI")]
    [SerializeField] TextMeshProUGUI pauseButtonText;
    [SerializeField] TextMeshProUGUI dataPathButtonText;
    [SerializeField] TextMeshProUGUI dataPathLabel;
    [SerializeField] TextMeshProUGUI dataPathText;

    bool isDataPathShown = true;

    /// <summary>
    /// Pause the image loader from updating the image with new scans
    /// </summary>
    public void Pause()
    {
        imageLoader.isPaused = !imageLoader.isPaused;

        // Update button text
        if (imageLoader.isPaused) pauseButtonText.text = "Resume";
        else pauseButtonText.text = "Pause";
    }

    /// <summary>
    /// Updates the camera's field of view based on the given parameter
    /// </summary>
    /// <param name="amount"> Amount camera FOV should be changed </param>
    public void ChangeCameraSize(int amount)
    {
        // Do not allow size change if camera is already at its min or max size
        if ((sceneCamera.fieldOfView >= cameraMaxSize && amount > 0) || 
            (sceneCamera.fieldOfView <= cameraMinSize && amount < 0))
            return;
        
        // If here, camera size can be changed as desired
        sceneCamera.fieldOfView += amount;
    }

    /// <summary>
    /// Toggles whether the data path is displayed on screen on and off
    /// </summary>
    public void ToggleDataPathDisplay()
    {
        // Update whether data path is visible
        isDataPathShown = !isDataPathShown;
        dataPathLabel.enabled = isDataPathShown;
        dataPathText.enabled = isDataPathShown;

        // Update button text
        if (isDataPathShown) dataPathButtonText.text = "Hide Data Path";
        else dataPathButtonText.text = "Show Data Path";
    }
}
