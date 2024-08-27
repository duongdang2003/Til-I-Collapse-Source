using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class CrystalLine : MonoBehaviour
{
    public float riseSpeed;
    public int crystalQuantity;
    public float startYPos;
    public float crystalGap;
    public int crystalRiseIndex;
    public bool rise = false;

    private Vector3 dir;
    public GameObject[] crystals;
    private void Awake() {
        crystals = new GameObject[crystalQuantity];
        crystalRiseIndex = 100;
    }
    void Start()
    {
    }

    void Update()
    {
        if(crystalRiseIndex < crystalQuantity){
            Vector3 target = crystals[crystalRiseIndex].transform.position;
            target.y = 0;
            float distance = Vector3.Distance(crystals[crystalRiseIndex].transform.position, target);
            if(distance > 0.01f){
                crystals[crystalRiseIndex].transform.position = Vector3.Lerp(crystals[crystalRiseIndex].transform.position, target, Time.deltaTime * riseSpeed);
            } else {         
                crystalRiseIndex++;
                if(crystalRiseIndex % 2 == 0)
                SoundManager.Instance.PlaySound(transform.root.GetComponent<AudioSource>(), SoundManager.Instance.iceRising);
            }
        } else if(crystalRiseIndex == crystalQuantity && rise){
            rise = false;
            StartCoroutine(CrystalFall());
        }
    }
    public void GetCrystal(){
        dir = transform.forward;
        
        for(int i=0; i < crystalQuantity; i++){
            crystals[i] = ObjectPool.Instance.GetObjectFromPool("crystal");
            crystals[i].transform.rotation = Quaternion.Euler(0, Random.Range(0, 360), 0);
            Vector3 crystalPos = transform.position + i*crystalGap*dir;
            crystalPos.y = startYPos;

            crystals[i].transform.position = crystalPos;
        }
        crystalRiseIndex = 0;
        rise = true;
    }
    private IEnumerator CrystalFall(){
        yield return new WaitForSeconds(0.5f);
        SoundManager.Instance.PlaySound(transform.root.GetComponent<AudioSource>(), SoundManager.Instance.iceBreak);
        for(int i=0; i < crystalQuantity; i++){
            if(i % 2 == 0){
                Vector3 crystPos = crystals[i].transform.position;
                GameObject spark = ObjectPool.Instance.GetObjectFromPool("basic spark");
                spark.transform.position = crystPos;
            }          
            crystals[i].SetActive(false);
        }
        gameObject.SetActive(false);
    }
}
