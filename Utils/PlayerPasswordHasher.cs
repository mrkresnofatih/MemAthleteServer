using MemAthleteServer.Templates;

namespace MemAthleteServer.Utils
{
    public class PlayerPasswordHasher : BcryptTemplate
    {
        protected override string GetSalt()
        {
            return "xrIWzK8BvewUPGHggBjW";
        }
    }
}