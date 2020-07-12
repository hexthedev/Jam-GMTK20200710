using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoveGiver : MonoBehaviour
{
    public List<ForceObject> objs;

    public BlackHoleStats stats;

    public float loveAttemptSeconds;
    public float loveChance;
    public float loveMultiple = 1;

    public SpawnAsteroid _spawn;
    public bool isDoneFirst = false;

    public CursorControl cur;

    public Sprite[] txts; 

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
                if (fo == null || !fo.isLovable) continue;

                if (Random.Range(0, 100f) <= loveChance)
                {
                    if (!isDoneFirst)
                    {
                        _spawn.isSpawning = true;
                        isDoneFirst = true;

                        Sprite sp = txts[Random.Range(0, txts.Length)];
                        Texter.instance.ShowTextSprite(sp, 3f);
                    }

                    FloatHeart fh = Instantiate(stats.floatHeart, transform);
                    fh.origin = transform;
                    fh.target = fo.transform;
                    fh.onEnd = () =>
                    {
                        if (fo != null && fo.rb != null)
                        {
                            stats.love += fo.rb.mass * loveMultiple;
                            //stats.loveValUI.text = $"{Mathf.Round(stats.love)}";
                            cur.SetLove(stats.love);
                            FaceSwapper.instance.ChangeFace(FaceSwapper.instance.faces.inlove, 2f);
                        }
                    };

                    if(Random.Range(0, 1f) < 0.1f)
                    {
                        Sprite sp = txts[Random.Range(0, txts.Length)];
                        Texter.instance.ShowTextSprite(sp, 3f);
                    }
                }
            }

            objs.RemoveAll(o => o == null);
        }
    }
}
