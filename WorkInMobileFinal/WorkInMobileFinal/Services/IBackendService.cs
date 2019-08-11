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
    }
}
