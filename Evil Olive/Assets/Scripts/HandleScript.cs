using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandleScript : MonoBehaviour
{
    private float rotSpeedHandle;
    public bool position;
   
    public int mirrorAngle;

    public GameObject mirror;
    public Animator anim;

    // data collection
    public int switchUsed;

    void Start()
    {
        rotSpeedHandle = 1500f;
        position = false;
        anim.SetBool("isRotating", false);
    }

    private void OnTriggerStay(Collider other)
    {
        if ((position == false) & (other.tag == "Player") & (Input.GetKeyDown(KeyCode.E)))
        {
            FindObjectOfType<audiomanager>().Play("Handle");
            transform.Rotate(0.0f, 0.0f, -rotSpeedHandle * Time.deltaTime);
            
            position = true;
            
            StartCoroutine(RotationMirror(mirror));

            // data collection
            switchUsed++;
        }
        else if ((position == true) & (other.tag == "Player") & (Input.GetKeyDown(KeyCode.E)) )
        {
            FindObjectOfType<audiomanager>().Play("Handle");
            transform.Rotate(0.0f, 0.0f, rotSpeedHandle * Time.deltaTime);
            
            position = false;

            StartCoroutine(RotationMirror2( mirror));

            // data collection
            switchUsed++;
        }
    }
  
    IEnumerator RotationMirror( GameObject target)
    {
        anim.SetBool("isRotating", true);
        FindObjectOfType<audiomanager>().Play("Rotate");
        for (int i = 0; i < mirrorAngle; i++)
        {
            target.transform.Rotate(0.0f, 1f, 0f, Space.Self);
            yield return new WaitForSeconds(0.01f);
        }
        FindObjectOfType<audiomanager>().Pause("Rotate");
        anim.SetBool("isRotating", false);
    }

    IEnumerator RotationMirror2( GameObject target)
    {
        anim.SetBool("isRotating", true);
        FindObjectOfType<audiomanager>().Play("Rotate");
        for (int i = 0; i < mirrorAngle; i++)
        {
            target.transform.Rotate(0.0f, -1f, 0f, Space.Self);
            yield return new WaitForSeconds(0.01f);
        }
        FindObjectOfType<audiomanager>().Pause("Rotate");
        anim.SetBool("isRotating", false);
    }

}

