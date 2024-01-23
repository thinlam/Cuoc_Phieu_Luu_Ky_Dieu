using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClickOpenNews : MonoBehaviour
{
    public GameObject OpenNews;
    private Button button;
    // Start is called before the first frame update
    void Start()
    {
        button = OpenNews.GetComponent<Button>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.G)) 
        {
            button.onClick.Invoke();
        }
    }
    public void QuitApp()
    {
        UnityEditor.EditorApplication.isPlaying = false;
    }
}
