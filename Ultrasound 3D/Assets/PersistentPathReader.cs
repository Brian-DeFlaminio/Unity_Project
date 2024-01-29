using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class ImageLoader : MonoBehaviour
{
    public RawImage rawImage; // Reference to the RawImage component in the Unity Editor
    public string fileName = "currentFrame.jpg"; // Adjust the file name as needed
    public float updateInterval = 0.1f; // Adjust the update interval as needed
    public Material material;

    private float lastUpdateTime;

    void Start()
    {
        lastUpdateTime = Time.time;
        LoadAndDisplayImage();
    }


    void Update()
    {
        // Update the image at the specified interval
        if (Time.time - lastUpdateTime > updateInterval)
        {
            LoadAndDisplayImage();
            lastUpdateTime = Time.time;
        }
    }

    void LoadAndDisplayImage()
    {
        // Get the path to the persistent data folder and the file name of the frame
        string persistentDataPath = Application.persistentDataPath;
        string filePath = Path.Combine(persistentDataPath, fileName);

        // Check if the file exists
        if (File.Exists(filePath))
        {
            // Debug.LogWarning("File path found! Writing...");
            // Load the image file into a byte array
            byte[] fileData = File.ReadAllBytes(filePath);

            // Create a Texture2D and load the image data into it
            Texture2D texture = new Texture2D(2, 2);
            texture.LoadImage(fileData);

            // Assign the texture to the RawImage component
            //rawImage.texture = texture;
            material.SetTexture("_MainTex", texture);
        }
        else
        {
            Debug.LogWarning("File not found: " + fileName);
        }
    }
}
