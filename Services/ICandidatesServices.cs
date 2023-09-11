using HiringAppv1._5.Models;

namespace HiringAppv1._5.Services
{
    

        public interface ICandidatesServices
        {
            List<Candidates> Get();
            Candidates Get(String id);
            Candidates Create(Candidates candidate);
            void Update(string id, Candidates candidate);
            void Remove(string id);



        }
    
}
