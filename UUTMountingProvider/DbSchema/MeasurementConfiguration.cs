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
    public partial class MeasurementConfiguration 
    { 

        [DataMember(Name="measurementId")]
        [Key,Required]
        public string MeasurementId { get; set; }

        [DataMember(Name="measurementPoint")]
        public string MeasurementPoint { get; set; }

        [DataMember(Name="mappedResource")]
        public string MappedResource { get; set; }

    }
}
