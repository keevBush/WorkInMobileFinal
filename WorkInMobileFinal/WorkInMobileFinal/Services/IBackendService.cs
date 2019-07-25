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
    }
}
