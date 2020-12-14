using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NPCMove : MonoBehaviour
{
    [SerializeField] Transform _destination;
    Transform temporaryDestination;
    Transform wallLocation;
    NavMeshAgent _navMeshAgent;
    GameObject player;
    [SerializeField] bool reached;
    [SerializeField] float fov;
    private RaycastHit hit;
    Vector2 _targetVector;
    NPCConnectedPatrol patrolling;
    public GameObject tabletcamera;
    public tabletaabt tabletaabt;
    bool i = true;
    int walls;
    // a thickness of 0 would mean it wouldn't exist, the sound works as if it's travelling through air
    [SerializeField] int weightWallThickness;
    // maximum to distance to still be hearable to AA-BT when walking (may implement difference between walking and running later on)
    [SerializeField] int weightHearingDistance;

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    void Start()
    {
        print(Vector2.Distance(new Vector2(transform.position.x, transform.position.z), new Vector2(_destination.transform.position.x, _destination.transform.position.z)));
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
            && hit.collider.transform == temporaryDestination)
        {
                SetDestination();
                _targetVector = new Vector2(_destination.transform.position.x, _destination.transform.position.z);
                patrolling.searching = false;
        }
        else if (player.GetComponent<PlayerMovement>().move != Vector3.zero
            && Vector3.Distance(_destination.transform.position, transform.position) < weightHearingDistance)
        {
            temporaryDestination = _destination;
            wallLocation = transform;
            while (i)
            {
                if (Physics.Linecast(wallLocation.position, temporaryDestination.position, out hit)
                    && hit.collider.transform == temporaryDestination)
                {
                    i = false;
                }
                else
                {
                    walls++;
                    wallLocation = hit.collider.transform;
                }
            }
            i = true;
            if (walls != 0 
                && Vector3.Distance(temporaryDestination.transform.position, transform.position) 
                + walls * (weightWallThickness) <= weightHearingDistance)
            {
                SetDestination();
                _targetVector = new Vector2(temporaryDestination.transform.position.x, temporaryDestination.transform.position.z);
                patrolling.searching = false;
                print("Hearing succesful");
            }
        }
        else if (new Vector2(transform.position.x, transform.position.z) == _targetVector && patrolling.searching == false)
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