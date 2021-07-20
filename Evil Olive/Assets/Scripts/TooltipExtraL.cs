using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TooltipExtraL : MonoBehaviour
{
    public Text bubbleText;
    private bool helpOpen;

    public GameObject helpPanel;

    // data collection
    public int helpUsed;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(StartTooltip());
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.H) && helpOpen == false)
        {
            StartCoroutine(HelpTooltip());

            // data collection
            helpUsed++;
        }
    }

    IEnumerator StartTooltip()
    {
        helpOpen = true;
        yield return new WaitForSeconds(2f);
        helpPanel.SetActive(true);
        bubbleText.text = "Yipeeee! \nA new level built by participants!";
        yield return new WaitForSeconds(4f);
        bubbleText.text = "Yipeeee! \nA new level built by participants!";
        yield return new WaitForSeconds(4f);
        bubbleText.text = "Yipeeee! \nA new level built by participants!";
        yield return new WaitForSeconds(4f);
        bubbleText.text = "I assume you know this already but you can teleport to the location of your reflection.";
        yield return new WaitForSeconds(4f);
        bubbleText.text = "Use WASD or the arrow keys to move around. Press space in order to use your powers.";
        yield return new WaitForSeconds(6f);
        bubbleText.text = "Alright, I let you focus! The whole Olive world depends on you! If you need my help again just press h!";
        yield return new WaitForSeconds(6f);
        helpPanel.SetActive(false);
        helpOpen = false;
    }

    IEnumerator HelpTooltip()
    {
        helpOpen = true;
        helpPanel.SetActive(true);
        bubbleText.text = "Just use WASD or the arrow keys to move around. If you want to use your powers press space.";
        yield return new WaitForSeconds(6f);
        bubbleText.text = "However if your reflection is not at a suitable location your powers won't work!";
        yield return new WaitForSeconds(6f);
        bubbleText.text = "If you need my help again just press h, but you are doing good, I'm sure you won't need it!";
        yield return new WaitForSeconds(6f);
        helpPanel.SetActive(false);
        helpOpen = false;
    }
}
