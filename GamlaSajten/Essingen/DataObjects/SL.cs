using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Essingen.DataObjects
{
    public class SL
    {
        public class DataObjects
        {

            public class Rootobject
            {
                public object Message { get; set; }
                public long ExecutionTime { get; set; }
                public ResponseData ResponseData { get; set; }
                public long StatusCode { get; set; }
            }

            public partial class ResponseData
            {
                public object[] Metros { get; set; }
                public long DataAge { get; set; }
                public Bus[] Buses { get; set; }
                public string LatestUpdate { get; set; }
                public object[] StopPointDeviations { get; set; }
                public object[] Ships { get; set; }
                public object[] Trains { get; set; }
                public Bus[] Trams { get; set; }
            }









            public class Bus
            {
                public string Destination { get; set; }
                public object[] Deviations { get; set; }
                public string DisplayTime { get; set; }
                public DateTime ExpectedDateTime { get; set; }
                public string LineNumber { get; set; }
                public int SiteId { get; set; }
                public string StopAreaName { get; set; }
                public int StopAreaNumber { get; set; }
                public string StopPointDesignation { get; set; }
                public int StopPointNumber { get; set; }
                public DateTime TimeTabledDateTime { get; set; }
                public string TransportMode { get; set; }
            }

            public class Stoppointdeviation
            {
                public Deviation Deviation { get; set; }
                public Stopinfo StopInfo { get; set; }
            }

            public class Deviation
            {
                public object Consequence { get; set; }
                public int ImportanceLevel { get; set; }
                public string Text { get; set; }
            }

            public class Stopinfo
            {
                public string GroupOfLine { get; set; }
                public string StopAreaName { get; set; }
                public int StopAreaNumber { get; set; }
                public string TransportMode { get; set; }
            }

            public class Tram
            {
                public string Destination { get; set; }
                public object[] Deviations { get; set; }
                public string DisplayTime { get; set; }
                public DateTime ExpectedDateTime { get; set; }
                public string LineNumber { get; set; }
                public int SiteId { get; set; }
                public string StopAreaName { get; set; }
                public int StopAreaNumber { get; set; }
                public string StopPointDesignation { get; set; }
                public int StopPointNumber { get; set; }
                public DateTime TimeTabledDateTime { get; set; }
                public string TransportMode { get; set; }
                public string GroupOfLine { get; set; }
                public int JourneyDirection { get; set; }
            }



            public class Device
            {
                public int id { get; set; }
                public string location { get; set; }
                public string devicename { get; set; }
                public int status { get; set; }
                public string value { get; set; }
            }



            //public class Rootobject
            //{
            //    public object ClientError { get; set; }
            //    public string ExecutionTime { get; set; }
            //    public DateTime LatestUpdate { get; set; }
            //    public object ServerError { get; set; }
            //    public Bus[] Buses { get; set; }
            //    public object[] Metros { get; set; }
            //    public object[] StopPointDeviations { get; set; }
            //    public object[] Trains { get; set; }
            //    public object[] Trams { get; set; }
            //}

            //public class Bus
            //{
            //    public string Destination { get; set; }
            //    public object[] Deviations { get; set; }
            //    public string DisplayTime { get; set; }
            //    public DateTime ExpectedDateTime { get; set; }
            //    public string LineNumber { get; set; }
            //    public int SiteId { get; set; }
            //    public string StopAreaName { get; set; }
            //    public int StopAreaNumber { get; set; }
            //    public string StopPointDesignation { get; set; }
            //    public int StopPointNumber { get; set; }
            //    public DateTime TimeTabledDateTime { get; set; }
            //    public string TransportMode { get; set; }
            //}

        }


    }
}