using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class HandPointer : MonoBehaviour
{
    [SerializeField] private InputActionReference triggerActionReference;
    [SerializeField] private SphereCollider spherecollider;

    private void OnEnable() {
        triggerActionReference.action.performed += OnActionPerformed;
        triggerActionReference.action.canceled += OnActionCanceled;
    }

    private void OnActionPerformed(InputAction.CallbackContext obj) => spherecollider.enabled = true;

    private void OnActionCanceled(InputAction.CallbackContext obj) => spherecollider.enabled = false;

    private void OnDisable() {
        triggerActionReference.action.performed -= OnActionPerformed;
        triggerActionReference.action.canceled -= OnActionCanceled;
    }
}
