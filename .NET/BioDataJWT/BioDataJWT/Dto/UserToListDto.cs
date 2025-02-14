namespace BioDataJWT.Dto
{
    public class UserToListDto
    {
        public Guid idOfUser { get; set; }
        public string nameOfUser { get; set; }
        public int? ageOfUser { get; set; }
        public string addressOfUser { get; set; }
        public string emailOfUser { get; set; }
        public string roleOfUser {  get; set; }
    }
}
