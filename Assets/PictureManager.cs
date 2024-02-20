using UnityEngine;

public class PictureManager : MonoBehaviour
{
    public GameObject[] pictures; // Array of picture GameObjects

    private int currentPictureIndex = 0; // Index of the currently displayed picture

    void Start()
    {
        // Disable all pictures at the start
        foreach (var picture in pictures)
        {
            picture.SetActive(false);
        }

        // Enable the first picture
        pictures[currentPictureIndex].SetActive(true);
    }

    public void ChangePicture(bool choseYes)
    {
        // Disable the current picture
        pictures[currentPictureIndex].SetActive(false);

        // Update the current picture index based on the user's choice
        if (choseYes)
        {
            currentPictureIndex = (currentPictureIndex + 1) % pictures.Length;
        }
        else
        {
            currentPictureIndex = (currentPictureIndex - 1 + pictures.Length) % pictures.Length;
        }

        // Enable the new current picture
        pictures[currentPictureIndex].SetActive(true);
    }
}
