using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(SphereShooter))]
[RequireComponent(typeof(AudioSource))]
public class ObjectSwitcher : MonoBehaviour
{

    [SerializeField] private Image imageDisplay;
    [SerializeField] private float timeBetweenImages = 2.0f; // время между сменой картинок
    [SerializeField] private GameObject PlayerCombPanel;
    private int currentImageIndex = 0; // индекс текущей картинки
    public int[] ShootNumbers;
    private int numberIndex;
    private SphereShooter shooter;
    public float[] ShootSpeed;
    public List<int> FigureIndexess = new List<int>();
    public List<VoiceImage> voiceImages = new List<VoiceImage>();
    private AudioSource AudioSource;// компонент Image на сцене, который будет отображать картинки
    private void Start()
    {
        shooter = GetComponent<SphereShooter>();
        AudioSource = GetComponent<AudioSource>();
    }
    public void Starting()
    {
        imageDisplay.gameObject.SetActive(true);
        // установим первую картинку
        ChangePlayAudioImage();
        // запустим корутину, которая будет менять картинки с заданным промежутком времени
        StartCoroutine(ChangeImage());
    }

    IEnumerator ChangeImage()
    {
        while (currentImageIndex <= FigureIndexess.Count)
        {

            currentImageIndex++;
            if (numberIndex <= ShootNumbers.Length && ShootNumbers[numberIndex] == currentImageIndex)
            {
                StartCoroutine(Shoot());
            }
            // устанавливаем новую картинку
            yield return new WaitForSeconds(timeBetweenImages);
            if (currentImageIndex == FigureIndexess.Count)
            {
                yield return new WaitForSeconds(timeBetweenImages);
                imageDisplay.enabled = false;
                PlayerCombPanel.SetActive(true);
                break;
            }
            // увеличиваем индекс текущей картинки
            if(currentImageIndex < FigureIndexess.Count)
            {
                ChangePlayAudioImage();
            }
        }
    }
    IEnumerator Shoot()
    {
        shooter.ShootTime = ShootSpeed[numberIndex];
        shooter.PrepareToShoot();
        Debug.Log("Shoot!");
        yield return new WaitForSeconds(ShootSpeed[numberIndex] + 0.5f);
        numberIndex++;
    }
    public void ChangePlayAudioImage()
    {
        imageDisplay.sprite = voiceImages[FigureIndexess[currentImageIndex]].image;
        AudioSource.clip = voiceImages[FigureIndexess[currentImageIndex]].Audio;
        AudioSource.Play();
    }
    [Serializable]
    public class VoiceImage
    {
        public Sprite image;
        public AudioClip Audio;
    }
}
