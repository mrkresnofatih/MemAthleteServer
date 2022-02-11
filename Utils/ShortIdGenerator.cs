using shortid;
using shortid.Configuration;

namespace MemAthleteServer.Utils
{
    public class ShortIdGenerator
    {
        private readonly GenerationOptions _generationOptions;

        public ShortIdGenerator()
        {
            _generationOptions = new GenerationOptions
            {
                UseNumbers = true,
                UseSpecialCharacters = false,
                Length = 16
            };
        }

        public string GenerateNewShortId()
        {
            return ShortId.Generate(_generationOptions);
        }
    }
}