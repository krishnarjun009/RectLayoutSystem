using UnityEngine;
using UnityEngine.EventSystems;

namespace CustomLayout
{
    [RequireComponent(typeof(RectTransform))]
    [DisallowMultipleComponent]
    public abstract class BaseLayoutCell : UIBehaviour
    {
        [HideInInspector] public int dataIndex = -1;

        private RectTransform m_rectTransform;
        protected RectTransform rectTransform
        {
            get
            {
                if (m_rectTransform == null)
                    m_rectTransform = GetComponent<RectTransform>();
                return m_rectTransform;
            }
        }

        public void SetAnchors(Vector2 min, Vector2 max)
        {
            rectTransform.anchorMin = min;
            rectTransform.anchorMax = max;
        }

        public void SetOffsetVertical(float top, float bottom)
        {
            rectTransform.offsetMin = new Vector2(rectTransform.offsetMin.x, bottom);
            rectTransform.offsetMax = new Vector2(rectTransform.offsetMax.x, -top);
        }

        public void SetOffsetHorizontal(float left, float right)
        {
            rectTransform.offsetMin = new Vector2(left, rectTransform.offsetMin.y);
            rectTransform.offsetMax = new Vector2(-right, rectTransform.offsetMax.y);
        }

        public float Width
        {
            get
            {
                return rectTransform.sizeDelta.x;
            }
            set
            {
                var sizeDelta = rectTransform.sizeDelta;
                sizeDelta.x = value;
                rectTransform.sizeDelta = sizeDelta;
            }
        }

        public float Height
        {
            get
            {
                return rectTransform.sizeDelta.y;
            }
            set
            {
                var sizeDelta = rectTransform.sizeDelta;
                sizeDelta.y = value;
                rectTransform.sizeDelta = sizeDelta;
            }
        }

        public float Left
        {
            get
            {
                var corners = new Vector3[4];
                rectTransform.GetLocalCorners(corners);
                return rectTransform.anchoredPosition.x + corners[0].x;
            }
            set
            {
                var corners = new Vector3[4];
                rectTransform.GetLocalCorners(corners);
                rectTransform.anchoredPosition = new Vector2(value - corners[0].x, 0);
            }
        }

        public float Top
        {
            get
            {
                var corners = new Vector3[4];
                rectTransform.GetLocalCorners(corners);
                return rectTransform.anchoredPosition.y + corners[1].y;
            }
            set
            {
                var corners = new Vector3[4];
                rectTransform.GetLocalCorners(corners);
                rectTransform.anchoredPosition = new Vector2(0, value - corners[1].y);
            }
        }

        public float Right
        {
            get
            {
                var corners = new Vector3[4];
                rectTransform.GetLocalCorners(corners);
                return rectTransform.anchoredPosition.x + corners[2].x;
            }
            set
            {
                var corners = new Vector3[4];
                rectTransform.GetLocalCorners(corners);
                rectTransform.anchoredPosition = new Vector2(value - corners[2].x, 0);
            }
        }

        public float Bottom
        {
            get
            {
                var corners = new Vector3[4];
                rectTransform.GetLocalCorners(corners);
                return rectTransform.anchoredPosition.y + corners[3].y;
            }
            set
            {
                var corners = new Vector3[4];
                rectTransform.GetLocalCorners(corners);
                rectTransform.anchoredPosition = new Vector2(0, value - corners[3].y);
            }
        }
    }
}
