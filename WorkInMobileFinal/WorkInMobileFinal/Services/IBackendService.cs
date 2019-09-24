using Refit;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WorkInMobileFinal.Models;

namespace WorkInMobileFinal.Services
{
    public interface IBackendService
    {
        [Post("/api/Demadeur/inscription")]
        Task Inscription([Body(BodySerializationMethod.Json)] string jsondata);

        [Post("/api/Demadeur/connexion")]
        Task<DemandeurIdentite> Connexion([Body(BodySerializationMethod.Json)]string jsondata);

        [Put("/api/Demadeur/update")]
        Task Update([Body(BodySerializationMethod.Json)] string jsondata);

        [Multipart]
        [Post("/api/Demadeur/upload/{fileType}")]
        Task<string> UploadFile(string fileType,[AliasAs("file")] StreamPart stream);

        [Post("/api/Demadeur/publications/new")]
        Task NewPublication([Body(BodySerializationMethod.Json)]string jsonData);

        [Post("/api/Entreprise/{id}/offres/{idOffre}/postuler")]
        Task Postuler(string id,string idOffre,[Body(BodySerializationMethod.Json)]string jsonData);

        [Post("/api/Demadeur/{id}/publications/{idPublication}/commentaires/new")]
        Task Commenter(string id, string idPublication, [Body(BodySerializationMethod.Json)]string jsonData);

        [Post("/api/Demadeur/{id}/conversations/{idConversation}/{to}/new")]
        Task EnvoyerMessage(string id,string idConversation ,string to, [Body(BodySerializationMethod.Json)]string jsonData);

        [Get("/api/Entreprise/propositions/page/{page}")]
        Task<IEnumerable<Proposition>> GetPropositions(int page);

        [Get("/api/Demadeur/{id}/notifications/")]
        Task<IEnumerable<Notification>> GetNotifications(string id );

        [Get("/api/Demadeur/{id}/publications/")]
        Task<IEnumerable<Publication>> GetPublications(string id);

        [Get("/api/Demadeur/publications/{idPublication}")]
        Task<Publication> GetPublication(string idPublication);
    }
}
