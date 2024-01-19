using MongoDB.Driver;
using Synthesis.Model;
using Synthesis.Connection;
using Synthesis.Domain.DTOs;
using MongoDB.Bson;

namespace  Synthesis.Repository
{
    public class MemberRepository : IMemberRepository {
        private readonly IMongoCollection<Member> _memberCollection;
        public MemberRepository(){
            IMongoDatabase database = ConnectionContext.ConnectionToMongo();
            _memberCollection = database.GetCollection<Member>("members");

        }

        public void Add(Member member){
            _memberCollection.InsertOne(member);  
        }

        public List<MemberDTO> Get() {
            FilterDefinition<Member> filter = Builders<Member>.Filter.Empty;
            var projection = Builders<Member>.Projection.Include("id").Include("userId").Include("workspaceId").Include("role");
            List<MemberDTO> result = _memberCollection.Find(filter).Project<MemberDTO>(projection).ToList();
            return result;
        }

        public Member GetById(string memberId){
            Member memberFound = _memberCollection.Find(x => x.Id == memberId).FirstOrDefault();
            if(memberFound == null){
                throw new ArgumentException("Member não encontrado.");
            }
            return memberFound;
        }

        public void Update(Member memberUpdated){

            var filter = Builders<Member>.Filter.Eq(x => x.Id, memberUpdated.Id);
            var update = Builders<Member>.Update
                .Set(x => x.UserId, memberUpdated.UserId)
                .Set(x => x.WorkspaceId, memberUpdated.WorkspaceId)
                .Set(x => x.Role, memberUpdated.Role);

            _memberCollection.UpdateOne(filter, update);    
        }
        
        public void Delete(string Id){
            var filter = Builders<Member>.Filter.Eq(x => x.Id, Id);
            _memberCollection.DeleteOneAsync(filter);    
        }
    }
}
