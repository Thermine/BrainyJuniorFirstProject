using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class ObjectSwitcher : MonoBehaviour
{
    public List<Sprite> images;
    public List<AudioClip> audios;// список картинок, которые нужно показывать
    public Image imageDisplay;
    public AudioSource AudioSource;// компонент Image на сцене, который будет отображать картинки
    public float timeBetweenImages = 2.0f; // время между сменой картинок
    public GameObject panel;
    private int currentImageIndex = 0; // индекс текущей картинки
    bool OneTime;
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player" && currentImageIndex == 0)
        {
            Starting();
            imageDisplay.gameObject.SetActive(true);
        }
    }
    void Starting()
    {
        // установим первую картинку
        imageDisplay.sprite = images[currentImageIndex];
        AudioSource.clip = audios[currentImageIndex];
        AudioSource.Play();
        // запустим корутину, которая будет менять картинки с заданным промежутком времени
        StartCoroutine(ChangeImage());
    }

    IEnumerator ChangeImage()
    {
        while (true)
        {
            // ждем заданное время
            yield return new WaitForSeconds(timeBetweenImages);

            // увеличиваем индекс текущей картинки
            currentImageIndex++;

            // если достигли конца списка, начинаем сначала
            if (currentImageIndex >= images.Count)
            {
                currentImageIndex = 0;
            }

            // устанавливаем новую картинку
            imageDisplay.sprite = images[currentImageIndex];
            AudioSource.clip = audios[currentImageIndex];
            AudioSource.Play();
            if (currentImageIndex == images.Count - 1)
            {

                yield return new WaitForSeconds(timeBetweenImages);
                imageDisplay.enabled = false;
                panel.SetActive(true);
                break;
            }

        }
    }
}
