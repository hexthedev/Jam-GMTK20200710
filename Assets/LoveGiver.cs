using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoveGiver : MonoBehaviour
{
    public List<ForceObject> objs;

    public BlackHoleStats stats;

    public float loveAttemptSeconds;
    public float loveChance;

    public void Start()
    {
        StartCoroutine(UpdateLove());
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        ForceObject obj = collision.gameObject.GetComponent<ForceObject>();
        if (obj == null) return;
        objs.Add(obj);
    }

    public void OnTriggerExit2D(Collider2D collision)
    {
        ForceObject obj = collision.gameObject.GetComponent<ForceObject>();
        if (obj == null) return;
        objs.Remove(obj);
    }

    IEnumerator UpdateLove()
    {
        while (true)
        {
            yield return new WaitForSeconds(loveAttemptSeconds);

            ForceObject[] obses = objs.ToArray();
            foreach (ForceObject fo in obses)
            {
                if (fo == null) continue;

                if (Random.Range(0, 100f) <= loveChance)
                {
                    FloatHeart fh = Instantiate(stats.floatHeart, transform);
                    fh.origin = transform;
                    fh.target = fo.transform;
                    fh.onEnd = () =>
                    {
                        if (fo != null && fo.rb != null)
                        {
                            stats.love += fo.rb.mass;
                            stats.loveValUI.text = $"{Mathf.Round(stats.love)}";
                        }
                    };
                }
            }

            objs.RemoveAll(o => o == null);
        }
    }
}
