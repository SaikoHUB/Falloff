using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player; // Référence au transform du joueur
    public Vector3 offset; // Décalage entre la caméra et le joueur

    void Start()
    {
        if (player == null)
        {
            player = GameObject.FindGameObjectWithTag("Player")?.transform;
            if (player == null)
            {
                Debug.LogWarning("Le joueur n'est pas assigné et aucun objet avec le tag 'Player' trouvé !");
                return;
            }
        }

        // Initialiser le décalage basé sur les positions initiales
        offset = transform.position - player.position;
    }

    void LateUpdate()
    {
        if (player != null)
        {
            // Mettre à jour la position de la caméra pour suivre le joueur
            transform.position = player.position + offset;
        }
    }
}