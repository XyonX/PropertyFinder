using System;
using System.Collections.Generic;

namespace PropertyFinder.Backend.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string ProfilePictureUrl { get; set; }
        public string UserType { get; set; } // Agent, Owner, Seeker
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }

        // Navigation properties
        public ICollection<Property> Properties { get; set; }
        public ICollection<Favorite> Favorites { get; set; }
        public ICollection<SavedSearch> SavedSearches { get; set; }
        public ICollection<Inquiry> SentInquiries { get; set; }
        public ICollection<Inquiry> ReceivedInquiries { get; set; }
        public ICollection<Review> Reviews { get; set; }
    }
}