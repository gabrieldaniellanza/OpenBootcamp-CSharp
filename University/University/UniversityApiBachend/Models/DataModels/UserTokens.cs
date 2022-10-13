namespace UniversityApiBackend.Models.DataModels
{
    public class UserTokens
    {
        public int Id { get; set; }
        public string Token { get; set; } = String.Empty;
        public string UserName{ get; set; } =String.Empty; 

        public TimeSpan Validity { get; set; }

        public string RefreshToken { get; set; } = String.Empty;

        public string EmailId { get; set; } = String.Empty;
        public Guid GuidId { get; set; }

        public DateTime ExpiredTime { get; set; }

    }
}
