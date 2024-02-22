using System;
using System.Linq;
using System.IO;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
//using Newtonsoft.Json;

namespace IO.Swagger.Models
{ 
    [DataContract]
    public partial class UutMountingInformation 
    { 
        [DataMember(Name="uutId")]
        [Key,Required]
        public string UutId { get; set; }

        [DataMember(Name = "slotId")]
        public string SlotId { get; set; }

        [DataMember(Name="chamberId")]
        public string ChamberId { get; set; }

        [DataMember(Name="numberOfMeasurementPoints")]
        public decimal? NumberOfMeasurementPoints { get; set; }

        //[DataMember(Name="measurementConfigurations")]
        //public List<MeasurementConfiguration> MeasurementConfigurations { get; set; }

    }
}
