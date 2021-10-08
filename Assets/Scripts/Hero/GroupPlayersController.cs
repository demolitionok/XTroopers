using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

struct UnitProp
{
    public Animator unitAnim;
    public Transform unitTransform;
    public NavMeshAgent unitNavMesh;
}

public class GroupPlayersController : MonoBehaviour
{
    [SerializeField] private FixedJoystick _joystick;
    
    [Header("Hero")]
    public List<GameObject> Heroes;
    
    private List<UnitProp> heroProp;
    private List<Vector3> heroPosPattern;
    private NavMeshAgent leaderNavMesh;

    void Start()
    {
        leaderNavMesh = GetComponent<NavMeshAgent>();
        GeneratePosPattern(); //запускать при смене количества персов
        GetHeroProp(); //запускать при смене количества персов
    }

    void Update()
    {
       GroupHeroMove();
    }

    private void GroupHeroMove(){
        if (_joystick.Horizontal !=0 || _joystick.Vertical !=0)
        {
            var moveDirection = new Vector3(_joystick.Horizontal, 0, _joystick.Vertical);
            var movePosition = transform.position + moveDirection;
            leaderNavMesh.SetDestination(movePosition);

            for(var i = 0; i < Heroes.Count; i++)
            {
                var heroMovePosition = transform.position + heroPosPattern[i];
                heroProp[i].unitNavMesh.SetDestination(heroMovePosition);
                heroProp[i].unitAnim.SetBool("isRun", true);
            }
        }
        else
        {
            for(var i = 0; i < Heroes.Count; i++)
            {
                float X = heroProp[i].unitTransform.position.x - transform.position.x;
                float Y = heroProp[i].unitTransform.position.y - transform.position.y;
                
                if(X >= 5 || X <= -5)
                {
                    var heroMovePosition = transform.position + heroPosPattern[i];
                    heroProp[i].unitNavMesh.SetDestination(heroMovePosition);
                    heroProp[i].unitAnim.SetBool("isRun", true);
                }
                else if(Y >= 5 || Y <= -5)
                {
                    var heroMovePosition = transform.position + heroPosPattern[i];
                    heroProp[i].unitNavMesh.SetDestination(heroMovePosition);
                    heroProp[i].unitAnim.SetBool("isRun", true);
                }
                else
                {
                    heroProp[i].unitAnim.SetBool("isRun", false);
                }
            }
        }
    }

    public void GeneratePosPattern()
    {
        List<Vector3> tempPosPattern = new List<Vector3>();

        switch (Heroes.Count)
        {
            case 1:
                tempPosPattern.Add(new Vector3(0,0,0));
                break;
            case 2:
                tempPosPattern.Add(new Vector3(-2f,0,0));
                tempPosPattern.Add(new Vector3(2f,0,0));
                break;
            case 3:
                tempPosPattern.Add(new Vector3(-2f,0,2f));
                tempPosPattern.Add(new Vector3(2f,0,2f));
                tempPosPattern.Add(new Vector3(0,0,-2f));
                break;
            case 4:
                tempPosPattern.Add(new Vector3(0,0,2f));
                tempPosPattern.Add(new Vector3(-2f,0,0));
                tempPosPattern.Add(new Vector3(2f,0,0));
                tempPosPattern.Add(new Vector3(0,0,-2f));
                break;
            case 5:
                tempPosPattern.Add(new Vector3(-2f,0,2f));
                tempPosPattern.Add(new Vector3(2f,0,2f));
                tempPosPattern.Add(new Vector3(-2f,0,-2f));
                tempPosPattern.Add(new Vector3(2f,0,-2f));
                tempPosPattern.Add(new Vector3(0,0,0));
                break;
            default:
                //персонажей нет
                break;
        }
        heroPosPattern = tempPosPattern;
    }

    public void GetHeroProp()
    {
        List<UnitProp> tempHeroProp = new List<UnitProp>();
        UnitProp unitProp = new UnitProp();

        for(var i = 0; i < Heroes.Count; i++)
        {
            unitProp.unitAnim = Heroes[i].GetComponent<Animator>();
            unitProp.unitTransform = Heroes[i].GetComponent<Transform>();
            unitProp.unitNavMesh = Heroes[i].GetComponent<NavMeshAgent>();
            tempHeroProp.Add(unitProp);
        }
        heroProp = tempHeroProp;
    }
}
