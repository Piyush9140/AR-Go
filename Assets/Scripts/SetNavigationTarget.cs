using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using TMPro;

public class SetNavigationTarget : MonoBehaviour
{
    /*[SerializeField]
    private TMP_Dropdown navigationTargetDropdown;*/
    [SerializeField]
    private Camera TopDownCamera;
    /*[SerializeField]
    private List<Target> navigationTargetObjects = new List<Target>();*/
    [SerializeField]
    private GameObject navTargetObject;
    private NavMeshPath path;
    private LineRenderer line;
    /*private Vector3 targetPosition = Vector3.zero; // CURRENT TARGET POSITION*/
    private bool lineToggle = false;
    private void Start()
    {
        path = new NavMeshPath();
        line = transform.GetComponent<LineRenderer>();
        /*line.enabled = lineToggle;*/
    }
    private void Update()
    {
        if ((Input.touchCount > 0) && (Input.GetTouch(0).phase == TouchPhase.Began))
        {
            lineToggle = !lineToggle;
        }
        if (lineToggle)
        {
            NavMesh.CalculatePath(transform.position, navTargetObject.transform.position, NavMesh.AllAreas, path);
            line.positionCount = path.corners.Length;
            line.SetPositions(path.corners);
            line.enabled = true;
        }
        /*if(lineToggle && targetPosition != Vector3.zero)
        {
            NavMesh.CalculatePath(transform.position, targetPosition, NavMesh.AllAreas, path);
            line.positionCount = path.corners.Length;
            line.SetPositions(path.corners);
        }
        }
        public void SetCurrentNavigationTarget(int selectedValue)
        {
        targetPosition = Vector3.zero;
        string selectedText = navigationTargetDropdown.options[selectedValue].text;
        Target currentTarget = navigationTargetObjects.Find(x => x.Name.ToLower().Equals(selectedText.ToLower()));
        if (currentTarget != null) {
            targetPosition = currentTarget.PositionObject.transform.position;

        }

        }*/
        /*public void ToogleVisibility()
        {
            lineToggle = !lineToggle;
            line.enabled = lineToggle;
        }*/
    }
}
