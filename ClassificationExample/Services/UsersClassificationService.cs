using Accord.MachineLearning.Bayes;
using Accord.Statistics.Distributions.Univariate;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ClassificationExample
{
    public class UsersClassificationService : IUsersClassificationService
    {
        private readonly NaiveBayes<NormalDistribution> _naiveBayes;

        public UsersClassificationService()
        {
            var learningSet = new List<Tuple<UserType, UserStatistics>>()
            {
                Tuple.Create(UserType.Average, new UserStatistics(3, 3, 1, 100.5)),
                Tuple.Create(UserType.Average, new UserStatistics(2, 2, 1, 100.5)),
                Tuple.Create(UserType.Average, new UserStatistics(3, 0, 4, 200.5)),
                Tuple.Create(UserType.Average, new UserStatistics(3, 1, 3, 175.0)),
                Tuple.Create(UserType.Average, new UserStatistics(1, 3, 1, 50.0 )),
                Tuple.Create(UserType.Average, new UserStatistics(0, 1, 3, 100.5)),
                Tuple.Create(UserType.Good,    new UserStatistics(4, 1, 7, 400.5)),
                Tuple.Create(UserType.Good,    new UserStatistics(2, 5, 7, 330.7)),
                Tuple.Create(UserType.Good,    new UserStatistics(5, 4, 6, 300.5)),
                Tuple.Create(UserType.Good,    new UserStatistics(6, 6, 6, 200.5)),
                Tuple.Create(UserType.Good,    new UserStatistics(4, 5, 6, 323.5)),
                Tuple.Create(UserType.Good,    new UserStatistics(6, 3, 3, 350.5)),
            };
                
            var learner = new NaiveBayesLearning<NormalDistribution>();

            var inputs = learningSet.Select(x => x.Item2.ToArray()).ToArray();
            var outputs = learningSet.Select(x => (int) x.Item1).ToArray();

            _naiveBayes = learner.Learn(inputs, outputs);
        }

        public UserType ClassifyUser(UserStatistics statistics)
        {
            var input = new double[] 
            {
                statistics.AccountAge,
                statistics.CommentsCount,
                statistics.DailyLoginsInRow,
                statistics.MoneySpent,
            };

            var result = _naiveBayes.Decide(input);

            return (UserType) result;
        }
    }
}