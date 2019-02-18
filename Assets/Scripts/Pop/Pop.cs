using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Pop : MonoBehaviour
{
    [SerializeField][ReadOnly]
    public Building Home;
    [SerializeField][ReadOnly]
    public Building Work;
    [SerializeField][ReadOnly]
    protected string Name;

    private static int JOB_SEARCH_RADIUS = 100;

    private void Start()
    {
        GameClock.OnTick += delegate (object sender, GameClock.OnTickEventArgs e) { OnTick(); };

        GetAJob();
    }

    private void OnTick()
    {
        if (Work == null)
        {
            GetAJob();
        }
    }

    public bool SetHome(Building building)
    {
        if (Home != null)
        {
            Debug.Log("I already have a home!");
            return false;
        }
        if (building.HasVacancy() == false)
        {
            Debug.Log("No vacancy in that building!");
            return false;
        }

        Home = building;
        return true;
    }

    public bool GetAJob()
    {
        if (Work != null)
        {
            Debug.Log("I already have a job");
            return false;
        }

        Collider[] nearby = Physics.OverlapSphere(transform.position, JOB_SEARCH_RADIUS);
        nearby.OrderBy(x => (this.transform.position - x.transform.position).sqrMagnitude).ToArray();
        for (int i = 0; i < nearby.Length; i++)
        {
            Building building = nearby[i].GetComponent<Building>();
            if (building == null) continue;
            if (building.HasEmployment())
            {
                if (building.TryHire(this))
                {
                    Work = building;
                    return true;
                }
            }
        }

        Debug.Log("No jobs found nearby!");
        return false;
    }

}
