using UnityEngine;
using UnityEngine.AI;
using UnityStandardAssets.Characters.ThirdPerson;

public class EnemyAI : MonoBehaviour
{
    public Transform player;
    public float detectionRange = 30f;
    public float fieldOfView = 60f;

    private NavMeshAgent agent;
    private AICharacterControl aiCharacterControl;
    private bool isChasing = false;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        aiCharacterControl = GetComponent<AICharacterControl>();
    }

    void Update()
    {
        if (!isChasing && CanSeePlayer())
        {
            isChasing = true;
            aiCharacterControl.SetTarget(player); // Assign player as the target
        }

        if (isChasing)
        {
            aiCharacterControl.SetTarget(player); // Keep updating the target if needed
        }
        else
        {
            aiCharacterControl.SetTarget(null); // Stop chasing if target is null
        }
    }

    private bool CanSeePlayer()
    {
        Vector3 directionToPlayer = player.position - transform.position;
        float angle = Vector3.Angle(transform.forward, directionToPlayer);
        if (angle < fieldOfView / 2 && directionToPlayer.magnitude <= detectionRange)
        {
            RaycastHit hit;
            if (Physics.Raycast(transform.position, directionToPlayer, out hit, detectionRange))
            {
                if (hit.transform == player)
                {
                    return true;
                }
            }
        }
        return false;
    }
}
