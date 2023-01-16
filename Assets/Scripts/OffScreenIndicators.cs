using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MEC;


namespace Custom.Indicators
{

    [RequireComponent(typeof(Canvas))]
    public class OffScreenIndicators : MonoBehaviour
    {
        // Start is called before the first frame update
        public Camera activeCamera;
        public List<Indicator> targetIndicators;
        public GameObject indicatorPrefab;
        public float checkTime = 0.1f;
        public Vector2 offSet;


        private Transform _trasform;
        void Start()
        {
            _trasform = transform;
            InstantiateIndicators();
            Timing.RunCoroutine(UpdateIndicators().CancelWith(gameObject));
        }

        public void AddTarget(GameObject targetObject)
        {
            targetIndicators.Add(new Indicator()
            {
                target = targetObject.transform
            });
            InstantiateIndicators();
        }

        public void RemoveTarget(GameObject targetObject)
        {
            int i = 0;
            foreach (var targetIndicator in targetIndicators)
            {

                if (targetIndicator.target == targetObject.transform)
                {
                    targetIndicators.RemoveAt(i);
                    break;
                }
                i++;
            }
        }

        public void InstantiateIndicators()
        {
            foreach (var targetIndicator in targetIndicators)
            {
                if (targetIndicator.indicatorUI == null)
                {
                    targetIndicator.indicatorUI = Instantiate(indicatorPrefab).transform;
                    targetIndicator.indicatorUI.SetParent(_trasform);
                }

                var rectTransform = targetIndicator.indicatorUI.GetComponent<RectTransform>();

                if (rectTransform == null)
                {
                    rectTransform = targetIndicator.indicatorUI.gameObject.AddComponent<RectTransform>();
                }

                targetIndicator.rectTransform = rectTransform;
            }
        }

        private void UpdatePositions(Indicator targetIndicator)
        {
            var rect = targetIndicator.rectTransform.rect;

            var indicatorPosition = activeCamera.WorldToScreenPoint(targetIndicator.target.position);
            if (indicatorPosition.z < 0)
            {
                indicatorPosition.y = -indicatorPosition.y;
                indicatorPosition.x = -indicatorPosition.x;
            }

            var newPosition = new Vector3(indicatorPosition.x, indicatorPosition.y, indicatorPosition.z);

            indicatorPosition.x = Mathf.Clamp(indicatorPosition.x, rect.width / 2, Screen.width - rect.width / 2) + offSet.x;
            indicatorPosition.y = Mathf.Clamp(indicatorPosition.y, rect.height / 2, Screen.height - rect.height / 2) + offSet.y;
            indicatorPosition.z = 0;

            targetIndicator.indicatorUI.up = (newPosition - indicatorPosition).normalized;
            targetIndicator.indicatorUI.position = indicatorPosition;
        }

        IEnumerator<float> UpdateIndicators()
        {
            while (true)
            {
                foreach (var targetIndicator in targetIndicators)
                {
                    UpdatePositions(targetIndicator);
                }
                yield return Timing.WaitForSeconds(checkTime);
            }
        }

    }

    [System.Serializable]
    public class Indicator
    {
        public Transform target;
        public Transform indicatorUI;
        public RectTransform rectTransform;
    }

}
