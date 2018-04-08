namespace ClassificationExample
{
    public class UserStatistics
    {
        public UserStatistics() { }

        public UserStatistics(int dailyLogins, int commentsCount, int accountAge, double moneySpent)
        {
            DailyLoginsInRow = dailyLogins;
            CommentsCount = commentsCount;
            AccountAge = accountAge;
            MoneySpent = moneySpent;
        }

        public double MoneySpent { get; set; }

        public int DailyLoginsInRow { get; set; }

        public int CommentsCount { get; set; }

        public int AccountAge { get; set; }

        public double[] ToArray()
        {
            return new double[]
            {
                DailyLoginsInRow,
                CommentsCount,
                AccountAge,
                MoneySpent,
            };
        }
    }
}