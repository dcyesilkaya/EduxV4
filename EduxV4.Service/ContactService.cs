using EduxV4.Data;
using EduxV4.Repo;
using System;
using System.Collections.Generic;

namespace EduxV4.Service
{
    public class ContactService : IContactService
    {
        private IRepository<Contact> contactRepository;

        public ContactService(IRepository<Contact> contactRepository)
        {
            this.contactRepository = contactRepository;
        }

        public IEnumerable<Contact> GetContacts()
        {
            return contactRepository.GetAll();
        }

        public IEnumerable<Contact> GetCandidateContacts()
        {
            return contactRepository.GetMany(c=>c.ContactStage == ContactStage.Candidate && c.ContactType == ContactType.Student, "Family", "ActivitiesFor", "ActivitiesFor.ActivityNextStep", "ActivitiesFor.Staff");
        }

        public IEnumerable<Contact> GetSiblingContacts(string id)
        {
            var contact = GetContact(id);
            return contactRepository.GetMany(c => c.ParentId != null && c.ParentId == contact.ParentId && c.Id != id, "ActivitiesFor", "ActivitiesFor.ActivityNextStep", "ActivitiesFor.Staff");
        }

        public IEnumerable<Contact> GetParentContacts()
        {
            return contactRepository.GetMany(c => c.FamilyRole == FamilyRole.Mother || c.FamilyRole == FamilyRole.Father || c.FamilyRole == FamilyRole.OtherParent);
        }

        public Contact GetContact(string id)
        {
            return contactRepository.Get(id);
        }

        public void InsertContact(Contact contact)
        {
            contactRepository.Insert(contact);
        }
        public void UpdateContact(Contact contact)
        {
            contactRepository.Update(contact);
        }

        public void DeleteContact(string id)
        {
            Contact contact = GetContact(id);
            contactRepository.Remove(contact);
            contactRepository.SaveChanges();
        }
    }
    public interface IContactService
    {
        IEnumerable<Contact> GetContacts();
        IEnumerable<Contact> GetCandidateContacts();
        IEnumerable<Contact> GetSiblingContacts(string id);
        IEnumerable<Contact> GetParentContacts();
        Contact GetContact(string id);
        void InsertContact(Contact contact);
        void UpdateContact(Contact contact);
        void DeleteContact(string id);
    }
}
