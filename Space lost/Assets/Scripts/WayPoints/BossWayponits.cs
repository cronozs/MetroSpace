using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossWayponits : MonoBehaviour
{
    [SerializeField] float speed = 1;
    [SerializeField] WayPointsManager_1 wayPointsManager;
    [SerializeField] WayPointsManager_1 wayPointsManage1;
    [SerializeField] WayPointsManager_1 wayPointsManage2;
    private int attack = 0;
    private WayPointsManager_1 desicion;
    private Vector2 currentPosition;
    private int chields; 
    int i = 0;


    private void Awake()
    {
        currentPosition = wayPointsManager.GetNextPoint();
    }

    void Update()
    {
        desicion = WhichAttack();
        chields = desicion.transform.childCount;
        Follow(chields, desicion);
    }

    void Follow(int chi, WayPointsManager_1 des)
    {
        i = 0;
        while (chi >= i)
        {
            if (Vector2.Distance(this.transform.position, currentPosition) > 0.1f)
            {
                var direction = currentPosition - (Vector2)this.transform.position;
                this.transform.Translate(direction.normalized * speed * Time.deltaTime);
            }
            else
            {
                currentPosition = des.GetNextPoint();
                i++;
            }
        }
    }

    WayPointsManager_1 WhichAttack()
    {
        attack = Random.Range(0, 3);
        switch(attack)
        {
            case 0:
                return wayPointsManager;
            case 1:
                return wayPointsManage1;
            case 2:
                return wayPointsManage2;
            default:    
                return wayPointsManage1;
        }
    }
}
