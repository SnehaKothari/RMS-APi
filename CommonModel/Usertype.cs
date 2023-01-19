using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using Newtonsoft.Json.Converters;
using System;
using System.Collections;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace recruitmentmanagementsystem.CommonModel
{
    public class Usertype
    {
       // [EnumDataType(typeof(string))]
      //  public User user { get; set; }
     
      [JsonConverter(typeof(StringEnumConverter))]
      public Type_of_User usertype { get; set; }

        public static implicit operator string(Usertype v)
        {
            throw new NotImplementedException();
        }
    }
    


}
