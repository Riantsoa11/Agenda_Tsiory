﻿using Agenda_V1_mety.Agenda_tsiory;  // Importation des espaces de noms nécessaires pour l'application Agenda.
using Microsoft.EntityFrameworkCore;  // Importation des espaces de noms nécessaires pour Entity Framework Core.
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agenda_V1_mety.Service.DAO
{
    class DAO_cantact
    {
        // Méthode pour vérifier si la base de données peut être connectée.
        public bool CheckDatabase()
        {
            using (var context = new AgendaAndrianasoloharisonContext())  // Création d'un contexte pour la base de données Agenda.
            {
                return context.Database.CanConnect();  // Vérification si la base de données peut être connectée.
            }
        }

        // Méthode pour récupérer tous les contacts de la base de données.
        public IEnumerable<Contact> GetContacts()
        {
            using (var context = new AgendaAndrianasoloharisonContext())  // Création d'un contexte pour la base de données Agenda.
            {
                return context.Contacts.ToList();  // Récupération de tous les contacts de la base de données.
            }
        }

        // Méthode pour ajouter un nouveau contact à la base de données.
        public void AjouterContact(Contact contact)
        {
            using (var context = new AgendaAndrianasoloharisonContext())  // Création d'un contexte pour la base de données Agenda.
            {
                context.Contacts.Add(contact);  // Ajout du nouveau contact au contexte.
                context.SaveChanges();  // Enregistrement des modifications dans la base de données.
            }
        }

        // Méthode pour modifier un contact existant dans la base de données.
        public void modifieContact(Contact contact)
        {
            if(contact != null)  // Vérification si le contact est null.
            {
                // Modification d'un contact.
                using (var context = new AgendaAndrianasoloharisonContext())  // Création d'un contexte pour la base de données Agenda.
                {
                    context.Contacts.Update(contact);  // Mise à jour du contact dans le contexte.
                    context.SaveChanges();  // Enregistrement des modifications dans la base de données.
                }
            }
            
        }

        // Méthode pour supprimer un contact de la base de données.
        public void SupprimerContact(Contact contact)
        {
            using (var context = new AgendaAndrianasoloharisonContext())  // Création d'un contexte pour la base de données Agenda.
            {
                context.Contacts.Remove(contact);  // Suppression du contact du contexte.
                context.SaveChanges();  // Enregistrement des modifications dans la base de données.
            }
        }

        // Méthode pour rechercher des contacts par nom.
        public IEnumerable<Contact> RechercherContactParNom(string nom)
        {
            using (var context = new AgendaAndrianasoloharisonContext())  // Création d'un contexte pour la base de données Agenda.
            {
                return context.Contacts.Where(c => c.Nom.Contains(nom)).ToList();  // Recherche des contacts par nom.
            }
        }

        // Méthode pour rechercher des contacts par prénom.
        public IEnumerable<Contact> RechercherContactParPrenom(string prenom)
        {
            using (var context = new AgendaAndrianasoloharisonContext())  // Création d'un contexte pour la base de données Agenda.
            {
                return context.Contacts.Where(c => c.Prenom.Contains(prenom)).ToList();  // Recherche des contacts par prénom.
            }
        }

        // Méthode pour rechercher des contacts par statut.
        public IEnumerable<Contact> RechercherContactStatut(string statut)
        {
            using (var context = new AgendaAndrianasoloharisonContext())  // Création d'un contexte pour la base de données Agenda.
            {
                return context.Contacts.Where(c => c.Statut == statut).ToList();  // Recherche des contacts par statut.
            }
        }
        //jointure entre contact et reseaux sociaux
        public IEnumerable<Contact> GetContactReseauxSociaux()
        {
            using (var context = new AgendaAndrianasoloharisonContext())
            {
                return context.Contacts.Include(c => c.ReseauSociauxes).ToList();
            }
        }

    }
}
