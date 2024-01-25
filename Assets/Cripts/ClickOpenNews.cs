using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Text;
using System;

public class NewsManager : MonoBehaviour
{
    public Text notificationText;

    

    private string[] notifications;
    private int currentIndex = 0;

    private void Start()
    {
        Console.OutputEncoding = Encoding.UTF8;
        // Initialize your news articles.
        notifications = new string[]
        {
            "              ",
            "Happy New years. ",
            "game sẽ được DEMO " +"vào 8/2024 ",
            
            // Add more articles as needed.
        };

        // Display the initial news article.
        ShowNotification();
    }

    private void Update()
    {
        // Example: Switch to the next article on space key press.
        if (Input.GetKeyDown(KeyCode.G))
        {
            ShowNextNotification();
        }
    }

    private void ShowNextNotification()
    {
        currentIndex = (currentIndex + 1) % notifications.Length;
        ShowNotification();
    }

    private void ShowNotification()
    {
        if (notificationText != null)
        {
            // Display the current news article.
            notificationText.text = notifications[currentIndex];
        }
    }
}
