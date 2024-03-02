using System;
using System.Collections;
using System.Collections.Generic;
using Unity.XR.CoreUtils;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
public class InteractiveElement : MonoBehaviour
{

    private XRSimpleInteractable interactable;
    private EnviromentController _enviromentController;
    
    private int targetViewIndex;

    private Animator uiAnim;
    
    //private Animator uiHover;
    
    private void Awake()
    {
        uiAnim = GetComponent<Animator>();
        interactable = GetComponent<XRSimpleInteractable>();
        
        interactable.hoverEntered.AddListener(OnHoverEntered);
        interactable.hoverExited.AddListener(OnHoverExited);
        interactable.activated.AddListener(OnActivate);
        
    }
    
    public void Initialize(EnviromentController manager, int targetIndex)
    {
        _enviromentController = manager;
        targetViewIndex = targetIndex;

        // Add interaction event listeners here
        // For example, using an XRButton component or similar
    }
    
    private void OnHoverEntered(HoverEnterEventArgs args)
    {
        // Play hover animation
        uiAnim?.SetTrigger("HoverStart");
    }

    private void OnHoverExited(HoverExitEventArgs args)
    {
        // Stop hover animation or revert to the default state
        uiAnim?.SetTrigger("HoverEnd");
    }
    private void OnActivate(ActivateEventArgs args)
    {
            _enviromentController.EnviromentIndex = targetViewIndex;
    }
    
}
