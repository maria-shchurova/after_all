using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SwitchRoom : MonoBehaviour
{
    [SerializeField] GameObject current;
    [SerializeField] GameObject next;

    [SerializeField] string animationTriggerName;
    [SerializeField] Animator CameraAnimator;
    [SerializeField] Animator DoorAnimator;

    [SerializeField] Transform PlayerCharacter;
    [SerializeField] Transform PlayerEnteringPoint;
    

    public void Switch()
    {
        DoorAnimator.SetTrigger("Close");

        current.SetActive(false);
        next.SetActive(true);

        PlayerCharacter.position = PlayerEnteringPoint.position;
        PlayerCharacter.rotation = PlayerEnteringPoint.rotation;
        PlayerCharacter.GetComponent<NavMeshAgent>().destination = PlayerEnteringPoint.position;

        CameraAnimator.SetTrigger(animationTriggerName);
    }
}
