using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using WorkInMobileFinal.Models;

namespace WorkInMobileFinal.ViewModels
{
    public class MessagerieViewModel:BaseViewModel
    {
        public ObservableCollection<Discussion> Discussions { get; set; }
        public MessagerieViewModel()
        {
            this.Discussions = new ObservableCollection<Discussion>();
            LoadData();
        }

        private  void LoadData()
        {
            var me = new DemandeurIdentite
            {
                Id = Guid.NewGuid().ToString(),
                Adresse = "Mon Adresse",
                Apropos = "A propos de moi",
                Email = "keevbush@gmail.com",
                Genre = Genre.Homme,
                LanguesParle = new List<string> { "Français", "Anglais", "Swahili" },
                Localisation = "Chez moi",
                Naissance = new DateTime(1997, 1, 22),
                Nom = "Bushiri",
                Password = "Pass",
                Postnom = "Abrantes",
                Prenom = "Kevin",
                Telephone = "+243972611411",
                Username = "keevbush"
            };
            for(int i = 1; i < 8; i++)
            {
                string id = Guid.NewGuid().ToString();
                this.Discussions.Add(new Discussion
                {
                    Id = id,
                    DemandeurIdentite= me,
                    EmployeurIdentite = new EmployeurIdentite
                    {
                        Id =id,
                        Adresse="Adresse "+i,
                        Domaines=new List<string> { "Info","Marketing"},
                        Email =$"info@entreprise{i}.com",
                        IdNational=$"ID-NAT-000{i}",
                        ImageProfil= "https://upload.wikimedia.org/wikipedia/commons/thumb/2/2a/ITunes_12.2_logo.png/768px-ITunes_12.2_logo.png",
                        Latitude=12,
                        Longitude=16,
                        MotDePasse="pwd",
                        Nom=$"Entreprise{i}"
                    },
                    Messages= new List<Message>
                    {
                        new Message
                        {
                            Date=new DateTime(2019,2,i),
                            Envoyeur= me,
                            Id=Guid.NewGuid().ToString(),
                            IsRead=true,
                            Msg= "Message oui "+i
                        },
                        new Message
                        {
                            Date=new DateTime(2019,2,i),
                            Envoyeur= me,
                            Id=Guid.NewGuid().ToString(),
                            IsRead=true,
                            Msg= "Message oui "+i
                        },
                        new Message
                        {
                            Date=new DateTime(2019,2,i),
                            Envoyeur= me,
                            Id=Guid.NewGuid().ToString(),
                            IsRead=true,
                            Msg= "Message oui "+i
                        },
                        new Message
                        {
                            Date=new DateTime(2019,2,i),
                            Envoyeur= me,
                            Id=Guid.NewGuid().ToString(),
                            IsRead=true,
                            Msg= "Message oui "+i
                        },
                        new Message
                        {
                            Date=new DateTime(2019,2,i),
                            Envoyeur= me,
                            Id=Guid.NewGuid().ToString(),
                            IsRead=true,
                            Msg= "Message oui "+i
                        }
                    }
                });
            }
        }
    }
}
