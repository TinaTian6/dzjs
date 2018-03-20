using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI : MonoBehaviour
{
    #region 变量 variable
    /// <summary>
    /// 速度
    /// </summary>
    [SerializeField] //保护封装性
    private float speed = 3f;
    /// <summary>
    /// 路标
    /// </summary>
    [SerializeField]
    private WayPoint targetPoint;
    [SerializeField]
    private WayPoint startPoint;
    /// <summary>
    /// 主角
    /// </summary>
    [SerializeField]
    private Hero mage;
	#endregion

	private void Start()
	{
        if(Vector3.Distance(transform.position,startPoint.transform.position) < 1e-2f)
        {
            targetPoint = startPoint.nextWayPoint1;
        }else{
            targetPoint = startPoint;
        }
        StartCoroutine(AINavMesh());
	}

    IEnumerator AINavMesh()
    {
        while(true)
        {
            if(Vector3.Distance(transform.position,targetPoint.transform.position) < 1e-2f)
            {
                targetPoint = targetPoint.nextWayPoint1;
                yield return new WaitForSeconds(2f);
            }
            if(mage != null && Vector3.Distance(transform.position,mage.gameObject.transform.position) <=6f)
            {
                print("侦察到敌人,开始攻击");
                yield return StartCoroutine(AIFollowHero());
            }
            Vector3 dir = targetPoint.transform.position - transform.position;
            transform.Translate(dir.normalized * Time.deltaTime * speed);
            yield return new WaitForEndOfFrame();
        }
    }
    IEnumerator AIFollowHero()
    {
        while(true)
        {
            if(mage != null && Vector3.Distance(transform.position,mage.gameObject.transform.position) >6f)
            {
                print("敌人已经走远,放弃攻击！！！");
                yield break;
            }
            Vector3 dir = mage.transform.position - transform.position;
            transform.Translate(dir.normalized * Time.deltaTime * speed * 0.8f);
            yield return new WaitForEndOfFrame();
        }

    }
}
