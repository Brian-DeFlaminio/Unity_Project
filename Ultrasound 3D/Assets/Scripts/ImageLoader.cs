using System.IO;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ImageLoader : MonoBehaviour
{
    [Header("Components")]
    [SerializeField] RawImage rawImage; // Reference to the RawImage component in the Unity Editor
    [SerializeField] Material material; // Material used by quad

    [Header("Global Variables")]
    [SerializeField] string fileName = "currentFrame.jpg"; // Adjust the file name as needed
    [SerializeField] float updateInterval = 0.1f; // Adjust the update interval as needed
    [HideInInspector] public bool isPaused = false; // Whether the image should update; hidden in inspector to avoid desync with button functions

    [Header("UI")]
    [SerializeField] TextMeshProUGUI dataPathText;

    string dataPath;
    string filePath;

    private float lastUpdateTime;

    // Start is called before the first frame update
    void Start()
    {
        SetDataPath();
        lastUpdateTime = Time.time;
        LoadAndDisplayImage();
    }

    // Update is called once per frame
    void Update()
    {
        if (!isPaused)
        {
            // Update the image at the specified interval
            if (Time.time - lastUpdateTime > updateInterval)
            {
                LoadAndDisplayImage();
                lastUpdateTime = Time.time;
            }
        }
    }

    /// <summary>
    /// Sets the data path and file path, and displays the data path on screen
    /// </summary>
    private void SetDataPath()
    {
        // Get the path to the persistent data folder and the file name of the frame
        dataPath = Application.persistentDataPath;
        filePath = Path.Combine(dataPath, fileName);
        dataPathText.text = dataPath;
    }

    /// <summary>
    /// Finds image from persistent data path and displays it to the plane
    /// </summary>
    private void LoadAndDisplayImage()
    {
        // Inside try-catch to avoid runtime pause error
        try
        {
            // Check if the file exists
            if (File.Exists(filePath))
            {
                // Load the image file into a byte array
                byte[] fileData = File.ReadAllBytes(filePath);

                // Create a Texture2D and load the image data into it
                Texture2D texture = new Texture2D(2, 2);
                texture.LoadImage(fileData);

                // Assign the texture to the RawImage component
                material.SetTexture("_MainTex", texture);
                Debug.Log("Updating image");
            }
            else
            {
                // File path not found
                Debug.LogWarning("File not found: " + fileName);
            }
        }
        catch
        {
            // Tried to retrieve file while it was being updated
            Debug.Log("Frame skipped");
        }

    }
}
