using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Poster : MonoBehaviour
{
    Animator animator;
    [SerializeField]GameObject mainImage;
    void Start()
    {
        animator = GetComponent<Animator>();
        animator.enabled = false;
        Messenger.AddListener("GoodPoster", GoodPosterOn);
        Messenger.AddListener("BadPoster", BadPosterOn);
        Messenger.AddListener("PosterDisplay", Display);
    }

    void Display()
    {
        mainImage.SetActive(true);
    }

    void GoodPosterOn()
    {
        animator.enabled = true;
        animator.SetTrigger("NoDrums");
    }
    void BadPosterOn()
    {
        animator.enabled = true;
        animator.SetTrigger("NoBass");
    }

    public void Delete()
    {
        Destroy(gameObject);
    }
}
