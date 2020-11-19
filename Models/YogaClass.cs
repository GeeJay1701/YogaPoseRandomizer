using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace YogaPoseRandomizer.Models
{
    public class YogaClass
    {
        public int PoseDuration { get; set; }

        public int PrepDuration { get; set; }

        public string Shavasana { get; set; }

        public int ShavasanaDuration { get; set; }

        public int TotalPoseMinutes
        {   
            get 
            {
                int count = 0;
                foreach (Pose p in PoseList)
                {
                    if(p.Type == "Double")
                    {
                        count++;
                    }
                }

                return PoseDuration * (PoseList.Length + count); 
            } 
        }

        public int TotalPoseIntervalSeconds
        {
            get
            {
                int count = 0;
                foreach (Pose p in PoseList)
                {
                    if (p.Type == "Double")
                    {
                        count++;
                    }
                }

                if (Shavasana != "None")
                    return PrepDuration * (PoseList.Length+count+1);
                else
                    return PrepDuration * (PoseList.Length+count);
                
            }
        }
        public string TotalClassTimeDsp
        {
            get
            {
                return new TimeSpan(0, TotalPoseMinutes + ShavasanaDuration, TotalPoseIntervalSeconds).ToString(@"mm\:ss");
            }        
        }

        public Pose[] PoseList { get; set; }

        public override string ToString() => JsonSerializer.Serialize<YogaClass>(this);
    }
}
