# Descrición

Escena en la que al escanear una determinada imagen con el movil, se instancia un personaje amarillo.

Mediante los botones de la interfaz se puede girar a este personaje a los lados, subirlo, bajarlo, hacer que muestre un mensaje, que gire continuamente y que se reproduzca un audio

# Título principal

**AR Marker**

## Subtítulo

Se han realizado los siguientes cambios:

- Se han cambiado la imagen y el prefab de **AR Tracked Image Manager** por **Marker Icons 2** y **JhonLemon** respectivamente
- Se le ha añadido al prefab de **JhonLemon** un **Canvas** con el tag *infoLemon* y un **AudioSource** con el tag *audioLemon*. Este audio contiene **SFXGhostMove**
- Se han modificado los métodos **PopUp()** y **PlayAudio()** del Script **ObjectController.cs** para hacer uso de los tags, y se han añadido los métodos **MoveUp()** y **MoveDown()** para mover al personaje arriba y abajo en el eje Y 
- Se ha añadido un método **PrepareSpin()** que desactiva las animaciones del personaje y cambia el valor del booleano *kukirigare* para que asi mediante el método **FixedUpdate()** el personaje gire coninuamente o no
- Se han añadido 3 botones al **Canvas** de la escena para llamar a los métodos **MoveUp()**, **MoveDown()** y **PrepareSpin()** 


```csharp
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


```