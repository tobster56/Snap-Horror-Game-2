using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NPCMove : MonoBehaviour
{
    [SerializeField] Transform _destination;
    NavMeshAgent _navMeshAgent;
    [SerializeField] bool reached;
    [SerializeField] float fov;
    private RaycastHit hit;
    Vector2 _targetVector;
    NPCConnectedPatrol patrolling;
    public GameObject tabletcamera;
    public tabletaabt tabletaabt;


    void Start()
    {
        _navMeshAgent = this.GetComponent<NavMeshAgent>();
        patrolling = this.GetComponent<NPCConnectedPatrol>();

        if (_navMeshAgent == null)
        {
            Debug.LogError("The nav mesh agent component is not attached to " + gameObject.name);
        }
        
    }

    private void Update()
    {
       if (tabletaabt.aabtSight == true)
        {
            Debug.Log("oh no");
            SetDestination();
            _targetVector = new Vector2(_destination.transform.position.x, _destination.transform.position.z);
            patrolling.searching = false;
        }
        LineOfSight(); 
    }

    private void LineOfSight()
    {
        if (Vector3.Angle(_destination.position - transform.position, transform.forward) <= fov 
            && Physics.Linecast(transform.position, _destination.position, out hit) 
            && hit.collider.transform == _destination)
        {
            SetDestination();
            _targetVector = new Vector2(_destination.transform.position.x,_destination.transform.position.z);
            patrolling.searching = false;
            
        }
        else if (new Vector2(transform.position.x, transform.position.z) == _targetVector)
        {
            patrolling.searching = true;
           
        }
    }
    private void SetDestination()
    {
        if (_destination != null)
        {
            Vector3 targetVector = _destination.transform.position;
            _navMeshAgent.SetDestination(targetVector);
        }
    }
}