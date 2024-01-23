using Synthesis.Model;
using Microsoft.AspNetCore.Authorization;
using Synthesis.Domain.DTOs;

namespace Synthesis.Services

{
    public class FlagCardAssociationServices : IFlagCardAssociationServices {
        private readonly IFlagCardAssociationRepository _flagCardAssociationRepository;
        private readonly ICardRepository _cardRepository;
        private readonly IFlagRepository _flagRepository;

        public FlagCardAssociationServices(IFlagCardAssociationRepository flagCardAssociationRepository, ICardRepository cardRepository, IFlagRepository flagRepository){
            _flagCardAssociationRepository = flagCardAssociationRepository ?? throw new ArgumentNullException(nameof(flagCardAssociationRepository));
            _cardRepository = cardRepository ?? throw new ArgumentNullException(nameof(cardRepository));
            _flagRepository = flagRepository ?? throw new ArgumentNullException(nameof(flagRepository));
        }

        public FlagCardAssociation CreateFlagCardAssociation(string CardId, string FlagId){

            Card cardFound = _cardRepository.GetById(CardId);
            if(cardFound == null){
                throw new ArgumentException("Card não encontrado.");
            }

            Flag flagFound = _flagRepository.GetById(FlagId);
            if(flagFound == null){
                throw new ArgumentException("Flag não encontrado");
            }

            FlagCardAssociation newFlagCardAssociation = new FlagCardAssociation(CardId, FlagId);
            _flagCardAssociationRepository.Add(newFlagCardAssociation);
            return newFlagCardAssociation;
        } 

        public List<FlagCardAssociationDTO> Get(){
            return _flagCardAssociationRepository.Get();
        }

        public FlagCardAssociation UpdateFlagCardAssociation(string Id, string CardId, string FlagId) {

            FlagCardAssociation flagCardAssociationFound = _flagCardAssociationRepository.GetById(Id);
            if(flagCardAssociationFound == null){
                throw new ArgumentException("FlagCardAssociation não encontrado.");
            }

            Card cardFound = _cardRepository.GetById(CardId);
            if(cardFound == null){
                throw new ArgumentException("Card não encontrado.");
            }

            Flag flagFound = _flagRepository.GetById(FlagId);
            if(flagFound == null){
                throw new ArgumentException("Flag não encontrada.");
            }


            flagCardAssociationFound.CardId = CardId;
            flagCardAssociationFound.FlagId = FlagId;

            _flagCardAssociationRepository.Update(flagCardAssociationFound);
            return flagCardAssociationFound;
        }
        
        public FlagCardAssociation DeleteFlagCardAssociation(string Id) {

            FlagCardAssociation flagCardAssociationFound = _flagCardAssociationRepository.GetById(Id);
            if(flagCardAssociationFound == null){
                throw new ArgumentException("FlagCardAssociation não encontrado.");
            }
            _flagCardAssociationRepository.Delete(Id);
            return flagCardAssociationFound;
        }

    }
}