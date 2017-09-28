using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace JLib
{
    public class ProgressBar : MonoBehaviour
    {
        public enum Direction
        {
            LeftToRight,
            RightToLeft,
            TopToBottom,
            BottomToTop
        }

        [SerializeField]
        Direction fiilDirection = Direction.LeftToRight;

        [SerializeField]
        [Range( 0f, 1f )]
        float percent = 0.5f;

        public Image fillImg = null;

        public float Value
        {
            get { return percent; }
			set { percent = value; }
        }

    }
}
