using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;
using TMPro;

public class RefernceManager : MonoBehaviour
{
    public static RefernceManager Instance;

    [Header("Screens")]
    public GameObject Weapons;
    public GameObject Points;
    public GameObject Instrument;
    public GameObject InventoryPopUp;

    [Header("Bools")]
    public bool Screens;

    [Header("Controller")]
    public FirstPersonController PlayerController;

    [Header("Check Point")]
    public Transform LatestCheckPoint;

    [Header("Particles System")]
    public GameObject[] Particles;

    [Header("Message Stings")]
    public string[] Message;

    [Header("Text")]
    public TMP_Text MessageText;

    [Header("Audio")]
    public AudioClip[] AudioClips;
    public AudioSource AudioSource;

    private void Start()
    {
        Instance = this;
    }

    public void TurnoffScreens()
    {
        Weapons.SetActive(false);
        Points.SetActive(false);
        Instrument.SetActive(false);
    }
    public void TurnOnScreen(GameObject Screen)
    {
        Screen.SetActive(true);
    }
    public void CusorCall()
    {
        if (PlayerController)
        {
            if (PlayerController.m_MouseLook.lockCursor)
                PlayerController.m_MouseLook.SetCursorLock(false);
            else
                PlayerController.m_MouseLook.SetCursorLock(true);
        }
        else 
        {
            Debug.LogError("Player Controller Is missing");
        }
    }
    public void OnClose() 
    {
        Screens = false;
        InventoryPopUp.SetActive(false);
        PlayerController.enabled = true;
    }
    public void PlayAudio(AudioClip Clip) 
    {
        AudioSource.clip = Clip;
        AudioSource.Play();
    }
}
