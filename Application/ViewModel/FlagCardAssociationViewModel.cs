using Microsoft.AspNetCore.Http;
using Synthesis.Model; 

namespace Synthesis.ViewModel
{
    public class FlagCardAssociationViewModel{
        public string CardId { get; set; }
        public string FlagId { get; set; }
        public FlagCardAssociationViewModel(string CardId, string FlagId){
            this.CardId = CardId;
            this.FlagId = FlagId;
        }
    }
}