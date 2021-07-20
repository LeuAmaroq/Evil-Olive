using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;
using UnityEngine.SceneManagement;

public class SaveData : MonoBehaviour
{
    public GameObject player;
    private PlayerController playerCont;
    private HandleScript mirror1;
    private HandleScript mirror2;
    private Reflexion reflexion;
    private Tooltip tooltip1;
    private TooltipL02 tooltip2;

    private int powerUsed;
    private int powerDisabled;
    private int switchUsed;
    private int switchMirror;
    private int helpUsed;
    private string sceneName;

    private float timeStart;
    private float timeStamp1;
    private float timeStamp2;

    private string data;

    private string dirPath;

    void Start() {
        string date = DateTime.Now.ToString("yyMMddHHmmss");
        //string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
        dirPath = Application.dataPath + "/SaveData" + date;
        if (!Directory.Exists(dirPath))
        {
            Directory.CreateDirectory(dirPath);
        }
        timeStart = Time.time;
        InvokeRepeating("AutoSave", 2.0f, 0.3f);
    }

    void AutoSave() {
        sceneName = SceneManager.GetActiveScene().name;

        if (sceneName == "Level01" || sceneName == "Level02")
        {
            player = GameObject.FindGameObjectWithTag("Player");
            playerCont = player.GetComponent<PlayerController>();
            reflexion = GameObject.FindGameObjectWithTag("Reflexion").GetComponent<Reflexion>();
            if (sceneName == "Level01")
            {
                tooltip1 = GameObject.FindGameObjectWithTag("CanvasHelp").GetComponent<Tooltip>();
            }
            else if (sceneName == "Level02")
            {
                mirror1 = GameObject.FindGameObjectWithTag("Handle1").GetComponent<HandleScript>();
                mirror2 = GameObject.FindGameObjectWithTag("Handle2").GetComponent<HandleScript>();
                tooltip2 = GameObject.FindGameObjectWithTag("CanvasHelp").GetComponent<TooltipL02>();
            }
        }

        if (sceneName == "Level01")
        {
            timeStamp1 = Time.time - timeStart;
            powerUsed = playerCont.powerUsed;
            powerDisabled = playerCont.powerDisabled;
            helpUsed = tooltip1.helpUsed;

            data = "- Log file -\n\nTimestamp: " + timeStamp1 + "\n--------------------------------------\n\nNumber of time power was used: " + powerUsed + "\nNumber of time failed attempt to use power: " + powerDisabled + "\nNumber of time tooltip was used: "+ helpUsed;

            File.WriteAllText(dirPath + "/saveDataL1.txt", data);

        }
        else if (sceneName == "Level02")
        {
            timeStamp2 = Time.time - timeStart - timeStamp1;
            powerUsed = playerCont.powerUsed;
            powerDisabled = playerCont.powerDisabled;
            helpUsed = tooltip2.helpUsed;
            switchMirror = reflexion.switchMirror;
            switchUsed = mirror1.switchUsed + mirror2.switchUsed;

            data = "- Log file -\n\nTimestamp: " + timeStamp2 + "\n--------------------------------------\n\nNumber of time power was used: " + powerUsed + "\nNumber of time failed attempt to use power: " + powerDisabled + "\nNumber of time tooltip was used: " + helpUsed + "\nNumber of time switched between mirrors: " + switchMirror + "\nNumber of time switches used: " + switchUsed;

            File.WriteAllText(dirPath + "/saveDataL2.txt", data);
        }
        else if (sceneName == "ThankYou")
        {
            data = "- Log file -\n\nThis is just to see if both levels were completed.";

            File.WriteAllText(dirPath + "/GameCompleted.txt", data);
        }
    }
}
