using UnityEngine;

public class ElephantScript : MonoBehaviour
{
    Animator animator;
    [SerializeField] Transform character;
    void Start()
    {
        animator = GetComponent<Animator>();
    }


    void React()
    {
        animator.SetTrigger("Headshake");
    }

    private void Update()
    {
        //transform.LookAt(new Vector3(character.position.x, transform.position.y, character.position.z));

        if (Vector3.Distance(transform.position, character.position) < 4)
        {
            React();
        }
    }
}
