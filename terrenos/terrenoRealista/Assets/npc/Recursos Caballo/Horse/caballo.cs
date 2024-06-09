using System.Collections;
using UnityEngine;

public class HorseController : MonoBehaviour
{
    private Animator animator;
    public float walkDuration = 5f; // Duración en segundos que el caballo caminará
    public float idleDuration = 3f; // Duración en segundos que el caballo estará en idle

    void Start()
    {
        // Obtener el componente Animator del caballo
        animator = GetComponent<Animator>();
        // Iniciar la secuencia de caminar y idle
        StartCoroutine(WalkAndIdle());
    }

    IEnumerator WalkAndIdle()
    {
        while (true) // Bucle infinito para alternar entre caminar y idle
        {
            // Hacer que el caballo camine
            animator.SetBool("isWalking", true);
            yield return new WaitForSeconds(walkDuration);

            // Hacer que el caballo esté en idle
            animator.SetBool("isWalking", false);
            yield return new WaitForSeconds(idleDuration);
        }
    }
}
