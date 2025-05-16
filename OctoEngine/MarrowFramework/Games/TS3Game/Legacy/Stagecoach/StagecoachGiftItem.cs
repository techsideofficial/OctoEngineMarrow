using System.Collections;
using MelonLoader;
using UnityEngine;

namespace AuroraFramework.TS3Game.Stagecoach
{
    public class StagecoachGiftItem : MonoBehaviour
    {
        public GameObject GiftBox;
        public GameObject GiftItem;
        public GameObject GiftItemParent;
        public GameObject GiftInstParent;
        public Animator GiftAnimator;
        public AnimationClip GiftDropClip;

        private Vector3 LPos;
        private GameObject _giftItemReference;
        private List<GameObject> _giftData;

        private void Start()
        {
            _giftData = GameObject.Find("AuroraManager").GetComponent<StagecoachGiftData>().GiftItems;
            if (GiftItem != null)
            {
                GiftDisablePhysics();
                GiftItem.transform.SetParent(GiftItemParent.transform, worldPositionStays: true);
                GiftItem.transform.localPosition = Vector3.zero;
            }
        }

        public void InitializeGift(GameObject GiftItemName)
        {
            GiftItem = Instantiate(GiftItemName);
            GiftDisablePhysics();
            GiftItem.transform.SetParent(GiftItemParent.transform, worldPositionStays: true);
            GiftItem.transform.localPosition = Vector3.zero;
        }

        public void BoxEnablePhysics()
        {
            GiftBox.GetComponent<Rigidbody>().useGravity = true;
            GiftBox.GetComponent<Rigidbody>().isKinematic = false;
        }

        public void BoxDisablePhysics()
        {
            GiftBox.GetComponent<Rigidbody>().useGravity = false;
            GiftBox.GetComponent<Rigidbody>().isKinematic = true;
        }

        private void GiftEnablePhysics()
        {
            GiftItem.GetComponentInChildren<Rigidbody>().useGravity = true;
            GiftItem.GetComponentInChildren<Rigidbody>().isKinematic = false;
        }

        private void GiftDisablePhysics()
        {
            GiftItem.GetComponentInChildren<Rigidbody>().useGravity = false;
            GiftItem.GetComponentInChildren<Rigidbody>().isKinematic = true;
        }

        public void GiftUnlock()
        {
            BoxDisablePhysics();
            GiftBox.GetComponent<MeshCollider>().enabled = false;
            GiftAnimator.Play(GiftDropClip.name);
#if UNITY_EDITOR
            StartCoroutine(GiftAnimDelay());
#else
            MelonCoroutines.Start(GiftAnimDelay());
#endif
        }

        private IEnumerator GiftAnimDelay()
        {
            yield return new WaitForSeconds(GiftDropClip.length);
            LPos = GiftItem.transform.localPosition;
            GiftItem.transform.SetParent(null, worldPositionStays: true);
            GiftBox.GetComponent<MeshCollider>().enabled = true;
            GiftBox.transform.SetParent(GiftInstParent.transform, worldPositionStays: false);
            GiftBox.transform.localPosition = Vector3.zero;
        }

#if MELONLOADER
        public StagecoachGiftItem(IntPtr ptr) : base(ptr) { }
#endif
    }
}