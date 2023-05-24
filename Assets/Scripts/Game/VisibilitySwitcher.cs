using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Deege.Game.Events;

public class VisibilitySwitcher : MonoBehaviour
{
    [SerializeField] public string VisibilityGroup;
    [SerializeField] public StringEventChannelSO OnGameSwitchVisibilityGroupEvent;
    [SerializeField] public GameObject VisibilityTarget;

    private void OnEnable()
    {
        if (OnGameSwitchVisibilityGroupEvent != null)
        {
            OnGameSwitchVisibilityGroupEvent.OnEventRaised += OnSwitch;
        }
    }

    private void OnDisable()
    {
        if (OnGameSwitchVisibilityGroupEvent != null)
        {
            OnGameSwitchVisibilityGroupEvent.OnEventRaised -= OnSwitch;
        }
    }

    private void OnSwitch(string stateTag)
    {
        bool isVisible = (stateTag == VisibilityGroup);
        VisibilityTarget.SetActive(isVisible);
    }
}
