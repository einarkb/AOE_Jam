using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChatBubbleManager : MonoBehaviour
{
    [SerializeField]
    private ChatBubble playerThinking;
    public ChatBubble PlayerThinking
    {
        get => playerThinking;
        private set => playerThinking = value;
    }

    [SerializeField]
    private ChatBubble playerSpeaking;
    public ChatBubble PlayerSpeaking
    {
        get => playerSpeaking;
        private set => playerSpeaking = value;
    }

    [SerializeField]
    private ChatBubble ownerThinking;
    public ChatBubble OwnerThinking
    {
        get => ownerThinking;
        private set => ownerThinking = value;
    }

    [SerializeField]
    private ChatBubble ownerSpeaking;
    public ChatBubble OwnerSpeaking
    {
        get => ownerSpeaking;
        private set => ownerSpeaking = value;
    }

}
