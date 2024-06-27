using UnityEngine;
using TMPro;
using FStudio.Utilities;
using System.Linq;
using System.Collections.Generic;
using FStudio.Graphics.Cameras;

namespace FStudio.MatchEngine.Players
{
    public class CircleUI : MonoBehaviour
    {
        public enum UIAnimatorVariable
        {
            ShowName,
            ShowOffside,
            ParameterCount // Parameter count of the animator.
        }

        private static readonly List<CircleUI> list = new List<CircleUI>();
        public static IEnumerable<CircleUI> Members => list.AsEnumerable();

        private int[] animatorVariableHashes;

        //private MainCamera mainCamera;

        [SerializeField] private Animator animator;

        public TextMeshPro nameText = default;

        Renderer color = default;
        MeshRenderer mColor = default;

        private void OnEnable()
        {
            list.Add(this);
        }

        private void OnDisable()
        {
            list.Remove(this);
        }
        private void Awake()
        {
            color = gameObject.GetComponent<Renderer>();
            Debug.Log("<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<testUI");
            //mColor = gameObject.GetComponent<MeshRenderer>();
            /*for (int i = 0; i < 11; i++)
            {
                MatchManager.Current.GameTeam1.GamePlayers[i].PlayerController.CUI.SetColor();
            }*/
            /*if (MatchManager.Current.GameTeam1)
            {
                Debug.Log("<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<circleUI");
                SetColor();
            }*/
            //SetColor();
        }


        public void SetBool(UIAnimatorVariable prop, bool value)
        {
            if (!animator.isActiveAndEnabled)
            {
                return;
            }

            animator.SetBool(animatorVariableHashes[(int)prop], value);
        }

        public void SetName(string name)
        {
            nameText.text = name;
        }

        public void SetColor()
        {
            color.material.color = Color.blue;
            //mColor.material.color = Color.blue;
        }

        public void SetColor2()
        {
            color.material.color = Color.red;
        }

        public void ShowOffside(bool value)
        {
            SetBool(UIAnimatorVariable.ShowOffside, value);
        }

        public void ShowName(bool value)
        {
            SetBool(UIAnimatorVariable.ShowName, value);
        }

        /*private void LateUpdate()
        {
            if (mainCamera == null)
            {
                mainCamera = MainCamera.Current;
            }

            var toCamera = Quaternion.LookRotation(transform.position - mainCamera.transform.position);
            toCamera.eulerAngles = new Vector3(toCamera.eulerAngles.x, toCamera.eulerAngles.y, 0);
            transform.rotation = toCamera;
        }*/
    }
}
