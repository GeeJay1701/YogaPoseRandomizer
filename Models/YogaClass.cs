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
        { get { return PoseDuration * PoseList.Length; } }

        public int TotalPoseIntervalSeconds
        { get { return PrepDuration * (PoseList.Length - 1); } }

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
