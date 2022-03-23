using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;



    [Serializable]
    public class Achievement:IAchievable
    {
        public string achievementName, achievementEvent, achievementConsequence;

        public Dictionary<string,bool> propertiestoCheck = new Dictionary<string,bool>();
        public int achievementStep, achievementSteps;
        public bool isCumulative, isLocked, isCompleted;


        

        public Achievement Poll()
        {
            foreach (string propertyToCheck in propertiestoCheck.Keys)
            {
                if (GameManager.Instance.monitorableProperties[propertyToCheck])
                {
                    if (!this.isCompleted)
                        return this;
                }
            }

            return null;
        }
        
    }