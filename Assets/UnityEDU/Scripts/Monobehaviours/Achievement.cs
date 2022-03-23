using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;




    [Serializable]
    public class Achievement
    {
        public string achievementName;

        public List<string> propertiestoCheck = new List<string>();
        public int achievementStep, achievementSteps;
        public bool isCumulative, isLocked, isCompleted;


        

        public Achievement Poll()
        {
            foreach (string propertyToCheck in propertiestoCheck)
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