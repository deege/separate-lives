using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Deege.Game.Events;

public class VisibilityManager : MonoBehaviour
{

    [SerializeField] public List<string> VisibilityGroup = new List<string>();
    [SerializeField] public VoidEventChannelSO OnPlayerSwitchButtonPressedEvent;
    [SerializeField] public StringEventChannelSO OnGameSwitchVisibilityGroupEvent;
    private int currentGroupIndex;


    void OnSwitch()
    {
        Debug.Log("Switch happening");
        if (VisibilityGroup.Count > 0)
        {
            ++currentGroupIndex;
            OnGameSwitchVisibilityGroupEvent.RaiseEvent(VisibilityGroup[currentGroupIndex % VisibilityGroup.Count]);
        }
    }

    private void OnEnable()
    {
        if (OnPlayerSwitchButtonPressedEvent != null)
        {
            OnPlayerSwitchButtonPressedEvent.OnEventRaised += OnSwitch;
        }
    }

    private void OnDisable()
    {
        if (OnPlayerSwitchButtonPressedEvent != null)
        {
            OnPlayerSwitchButtonPressedEvent.OnEventRaised -= OnSwitch;
        }
    }
}
