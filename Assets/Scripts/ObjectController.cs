using UnityEngine;

public class ObjectController : MonoBehaviour
{
    bool kukirigare=false;
    GameObject[] items;

    public void RotateLeft()
    {
        // findobjects with tag "modelObject"
        GameObject[] objects = GameObject.FindGameObjectsWithTag("modelObject");

        foreach (GameObject obj in objects)
        {
            obj.transform.Rotate(0, 15, 0);
        }   
    }

    public void RotateRight()
    {
        // findobjects with tag "modelObject"
        GameObject[] objects = GameObject.FindGameObjectsWithTag("modelObject");

        foreach (GameObject obj in objects)
        {
            obj.transform.Rotate(0, -15, 0);
        }   
    }

    public void MoveUp()
    {
        // findobjects with tag "modelObject"
        GameObject[] objects = GameObject.FindGameObjectsWithTag("modelObject");

        foreach (GameObject obj in objects)
        {
            obj.transform.position += obj.transform.up * 0.1f;
        }   
    }

    public void MoveDown()
    {
        // findobjects with tag "modelObject"
        GameObject[] objects = GameObject.FindGameObjectsWithTag("modelObject");

        foreach (GameObject obj in objects)
        {
            obj.transform.position += obj.transform.up * -0.1f;
        }   
    }

    public void PopUp()
    {
        // findobjects with tag "modelObject"
        GameObject[] objects = GameObject.FindGameObjectsWithTag("infoLemon");

        foreach (GameObject obj in objects)
        {
            Canvas canvas = obj.GetComponent<Canvas>();
            if (canvas != null)
            {
               canvas.enabled = !canvas.enabled;
            }   
        }   
    }  

    public void PlayAudio()
    {
        // findobjects with tag "modelObject"
        GameObject[] objects = GameObject.FindGameObjectsWithTag("audioLemon");

        foreach (GameObject obj in objects)
        {
            AudioSource audioSource = obj.GetComponent<AudioSource>();
            if (audioSource != null)
            {
                if (audioSource.isPlaying)
                {
                    audioSource.Pause();
                }
                else
                {
                    audioSource.Play();
                }
            }   
        }
    }

    public void PrepareSpin()
    {
        kukirigare=!kukirigare;

        GameObject[] objects = GameObject.FindGameObjectsWithTag("modelObject");

        foreach (GameObject obj in objects)
        {
            Animator anim = obj.GetComponentInChildren<Animator>();
            if (kukirigare)
            {
               anim.speed = 0;
            } else
            {
                anim.speed = 1;
            }
        }
    }

    void FixedUpdate()
    {
        if (kukirigare)
        {
            if (items == null)
            {
                items = GameObject.FindGameObjectsWithTag("modelObject");
            } else
            {
                foreach(GameObject i in items)
                {
                    i.transform.Rotate(0, 36, 0);
                }                
            }
        }
    }
}
