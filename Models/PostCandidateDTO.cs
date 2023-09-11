using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using HiringAppv1._5.Models;

namespace HiringAppv1._5.Models
{
   
    public class PostCandidateDTO
    {


        [BsonRequired]
        public string Name { get; set; } = String.Empty;

        [BsonRequired]
        public string email { get; set; }

        [BsonRequired]
        public string MobileNo { get; set; }

        [BsonRepresentation(BsonType.String)]
        public string JobType { get; set; }


        [BsonRepresentation(BsonType.String)]
        public OverallStatus OverallStatus { get; set; }

        [BsonRequired]
        public string CreatedBy { get; set; }

        [BsonRequired]
        public string UpdatedBy { get; set; }

        public bool AddForLater { get; set; }
    }

    public class UpdateCandidteDTO
    {

        public string? Name { get; set; } 

        public string? email { get; set; }
                
        public string? MobileNo { get; set; }

        [BsonRepresentation(BsonType.String)]
        public string? JobType { get; set; }

        [BsonRepresentation(BsonType.String)]
        public OverallStatus OverallStatus { get; set; }
       
        public string? CreatedBy { get; set; }
    
        public string? UpdatedBy { get; set; }

      
        public bool? AddForLater { get; set; }

    }

}
