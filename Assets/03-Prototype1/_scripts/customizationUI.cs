using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class customizationUI : MonoBehaviour
{
    public GameObject player;
    public GameObject customiztioRoom;

    public GameObject playUI;
    public GameObject customizationRoomUI;

    private bool isPlaying;

    private void Start()
    {
        ToggleCusomization(true);
    }

    public void ToggleCusomization(bool visible)
    {
        isPlaying = visible;

        player.SetActive(isPlaying);
        customiztioRoom.SetActive(!isPlaying);

        playUI.SetActive(isPlaying);
        customizationRoomUI.SetActive(!isPlaying);
    }
}