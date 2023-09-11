using HiringAppv1._5.Models;
using MongoDB.Driver;

namespace HiringAppv1._5.Services
{
    public class CandidatesServices : ICandidatesServices
    {
        private readonly IMongoCollection<Candidates> _candidates;

    public CandidatesServices(IDatabaseSettings settings, IMongoClient mongoClient)
        {
            var database = mongoClient.GetDatabase(settings.DatabaseName);
            _candidates = database.GetCollection<Candidates>(settings.CollectionName);
        }

        public Candidates Create(Candidates candidate)
        {
            _candidates.InsertOne(candidate);
            return candidate;
        }

        public List<Candidates> Get()
        {
            return _candidates.Find(candidate => true).ToList();
        }

        public Candidates Get(string id)
        {
            return _candidates.Find(candidate => candidate.Id == id).FirstOrDefault();
        }

        public void Remove(string id)
        {
            _candidates.DeleteOne(candidate => candidate.Id == id);
        }

        public void Update(string id, Candidates candidate)
        {
           // _candidates.UpdateOne(id, candidate, null);   
            _candidates.ReplaceOne(candidate => candidate.Id == id, candidate);
        }
    }

}
