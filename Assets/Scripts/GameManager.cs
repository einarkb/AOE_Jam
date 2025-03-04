﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; set; }

    [SerializeField]
    private Player player;
    public Player Player
    {
        get => player;
        private set => player = value;
    }

    [SerializeField]
    private Owner owner;
    public Owner Owner
    {
        get => owner;
        private set => owner = value;
    }

    [SerializeField]
    private Camera cam;
    public Camera Cam
    {
        get => cam;
        set => cam = value;
    }

    [SerializeField]
    private TaskManager taskManager;
    public TaskManager TaskManager
    {
        get => taskManager;
        set => taskManager = value;
    }

    [SerializeField]
    private ChatBubbleManager chatBubbleManager;
    public ChatBubbleManager ChatBubbleManager
    {
        get => chatBubbleManager;
        set => chatBubbleManager = value;
    }

    [SerializeField]
    private Canvas canvas;
    public Canvas Canvas
    {
        get => canvas;
        set => canvas = value;
    }


    [SerializeField]
    private float parallaxStrength = 2f;
    public float ParallaxStrength
    {
        get => parallaxStrength;
        set => parallaxStrength = value;
    }

    public MainMenu mainMenu;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }

   
}
