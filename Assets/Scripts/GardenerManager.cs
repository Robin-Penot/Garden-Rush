using UnityEngine;
using UnityEngine.AI;
using System.Collections.Generic;

public class GardenerManager : MonoBehaviour
{
    public NavMeshAgent agent;
    public LayerMask ground;
    private Queue<Vector3> ListDestination = new Queue<Vector3>();

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, Mathf.Infinity, ground))
                ListDestination.Enqueue(hit.point);
        }
        if (!agent.hasPath && ListDestination.Count > 0) agent.destination = ListDestination.Dequeue();
    }
}
