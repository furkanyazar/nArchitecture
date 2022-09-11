using Core.Persistence.Repositories;
using Core.Security.Entities;
using Kodlama.io.Devs.Domain.Enums;

namespace Kodlama.io.Devs.Domain.Entities
{
    public class SocialMedia : Entity
    {
        public int UserId { get; set; }
        public string Url { get; set; }
        public SocialMediaType SocialMediaType { get; set; }

        public User? User { get; set; }

        public SocialMedia() { }

        public SocialMedia(int id, int userId, string url, SocialMediaType socialMediaType) : this()
        {
            Id = id;
            UserId = userId;
            Url = url;
            SocialMediaType = socialMediaType;
        }
    }
}
