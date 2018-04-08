namespace ClassificationExample
{
    public interface IUsersClassificationService
    {
        UserType ClassifyUser(UserStatistics statistics);
    }
}