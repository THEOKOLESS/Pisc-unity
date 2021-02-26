﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Xml;
using UnityEditor.UIElements;
using UnityEngine;

namespace ex04
{
    public class SelectionController : MonoBehaviour
    {
        private Vector3 worldPosition;
        [HideInInspector]public List<Footman> footmanSelectedList;
        private Collider2D collider2d;
        private Collider2D attack;
        private Footman footman;
        // private FootmanSound footmanSound;

        public static SelectionController instance { get; private set; }

        private List<Vector3> targetPositionList;

        private void Awake(){
            if (instance == null)
                instance = this;
        }
        // Start is called before the first frame update
        void Start()
        {
            footmanSelectedList = new List<Footman>();
             Attack.instance.OnAttack += OnAttackLithener;
        }



        private void OnEnable()
        {
            //   Attack.instance.OnAttack += OnAttackLithener;
        }
        private void OnDisable()
        {
              Attack.instance.OnAttack -= OnAttackLithener;
        }
        void OnAttackLithener()
        {
            if (attack != null && footmanSelectedList.Count > 0)
            {

                foreach (Footman footman in footmanSelectedList)
                {
                    footman.SetAttack(true);
                    footman.SetEnemy(attack);
                }

                if (Footman.instance && Footman.instance.timing >= 0.9f)
                {
                    FootmanSound.instance.PlayAttackClip();
                }
            }
            else if (footmanSelectedList.Count > 0)
            {
                foreach (Footman footman in footmanSelectedList)
                {
                        footman.SetAttack(false);
                }
            }
        
        }
        // Update is called once per frame
        private void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                worldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                worldPosition.z = 0f;
                if (worldPosition != null)
                {
                    collider2d = Physics2D.OverlapPoint(worldPosition, LayerMask.GetMask("Footman"));
                    if (collider2d != null)
                    {
                        footman = collider2d.GetComponent<Footman>();
                        // footmanSound = collider2d.GetComponent<FootmanSound>();
                    }
                    if (!Input.GetKey(KeyCode.LeftControl) && collider2d)
                    {
                        ClearFootmanList();
                        attack = null;
                    }

                    if (!Input.GetKey(KeyCode.LeftControl))
                    {
                        if (footmanSelectedList.Count > 0)
                        {
                            attack = Physics2D.OverlapPoint(worldPosition, LayerMask.GetMask("Orc"));
                            if (attack == null)
                            {
                                targetPositionList = GetPositionListAround(worldPosition, new float[] { 1f, 2f, 3f }, new int[] { 5, 10, 20 }, false);
                                int targetPositionListIndex = 0;
                                foreach (Footman footman in footmanSelectedList)
                                {
                                    footman.MoveTo(targetPositionList[targetPositionListIndex]);
                                    targetPositionListIndex = (targetPositionListIndex + 1) % targetPositionList.Count;
                                }
                            }
                            FootmanSound.instance.PlayAcknowledgeClip();
                        }
                    }
                    if (collider2d != null)
                    {
                        FootmanSound.instance.PlaySelectedClip();
                        footmanSelectedList.Add(footman);
                        footman.SetSelectedVisible(true);
                    }
                }
               
            }
            else if (Input.GetMouseButtonDown(1))
            {
                ClearFootmanList();
                attack = null;
            }
        }
          
    private List<Vector3> GetPositionListAround(Vector3 startPos, float[] ringDistanceArray, int[] ringPositionArray, bool attack)
    {
        List<Vector3> positionList = new List<Vector3>();
        if (attack == false)
            positionList.Add(startPos);
        for (int i = 0; i < ringDistanceArray.Length; i++)
        {
            positionList.AddRange(GetPositionListAround(startPos, ringDistanceArray[i], ringPositionArray[i]));
        }
        return (positionList);
    }
    private List<Vector3> GetPositionListAround(Vector3 startPosition, float dist, int posCount)
    {
        List<Vector3> positionList = new List<Vector3>();
        for (int i = 0; i < posCount; i++)
        {
            float angle = i * (360f / posCount);
            Vector3 dir = ApplyRotationToVector(new Vector3(1, 0), angle);
            Vector3 position = startPosition + dir * dist;
            positionList.Add(position);
        }
        return positionList;
    }

    private Vector3 ApplyRotationToVector(Vector3 vec, float angle)
    {
        return Quaternion.Euler(0, 0, angle) * vec;
    }

        private void ClearFootmanList()
        {
            foreach (Footman footman in footmanSelectedList)
            {
                footman.SetSelectedVisible(false);
            }
            footmanSelectedList.Clear();
        }
    }
}
