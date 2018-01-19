using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NPCMove : MonoBehaviour
{
    /*  What is SerializeField?
     *  In Unity, if you want an attribute to show up in the Inspector, then that field has to be public. However, in 
     *  some cases, you may want a private field to show up in the Inspector, in which case if you declare it private 
     *  but put [SerializeField] before it (above it) then it will show up in the Inspector! Cool... now if I could
     *  only figure out WHY I would want to have it private AND show up in the inspector?!
     */
    //[SerializeField]
    //private Transform _destination;

    private GameObject molly;
    private NavMeshAgent _navMeshAgent;

    // Use this for initialization
    void Start()
    {
        _navMeshAgent = this.GetComponent<NavMeshAgent>();
        molly = GameObject.FindGameObjectWithTag("Molly");
    }

    void Update()
    {
        if (_navMeshAgent == null)
        {
            Debug.Log("The nav mesh agent is not attached to " + gameObject.name);
        }
        else
        {
            SetDestination();
        }
    }

    private void SetDestination()
    {
        if (molly == null)
        {
            Debug.Log("There is no destination set.");
        }
        else
        {
            Vector3 targetVector = molly.transform.position;
            _navMeshAgent.SetDestination(targetVector);
        }
    }
}