using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Money_Matters
{
    class Program
    {
        static void Main(string[] args)
        {
            var friendsAndFriendships = Console.ReadLine().Split(' ');
            var friends = int.Parse(friendsAndFriendships[0]);
            var friendships = int.Parse(friendsAndFriendships[1]);

            var debts = new Dictionary<int, int>();

            for (int i = 0; i < friends; i++)
                debts.Add(i, int.Parse(Console.ReadLine()));

            var listOfFriendships = new List<Friendship>();

            for (int i = 0; i < friendships; i++)
            {
                var tempInput = Console.ReadLine().Split(' ');
                listOfFriendships.Add(new Friendship(int.Parse(tempInput[0]), int.Parse(tempInput[1])));
            }

            var dicFriends = new Dictionary<int, List<int>>();

            for (int i = 0; i < friends; i++)
                dicFriends.Add(i, new List<int>());

            for (int i = 0; i < friendships; i++)
            {
                dicFriends[listOfFriendships[i].X].Add(listOfFriendships[i].Y);

                if (!dicFriends[listOfFriendships[i].Y].Contains(listOfFriendships[i].X))
                    dicFriends[listOfFriendships[i].Y].Add(listOfFriendships[i].X);
            }

            bool possible = true;

            while (dicFriends.Count > 0 && possible)
            {
                var cluster = new Dictionary<int, int>();
                cluster = RecursiveFest(dicFriends.Keys.First(), cluster, dicFriends, debts);
                dicFriends = RemoveClusterFromDicFriends(cluster, dicFriends);

                possible = (cluster.Sum(x => x.Value) == 0);
            }

            Console.WriteLine(possible ? "POSSIBLE" : "IMPOSSIBLE");
        }

        static Dictionary<int, List<int>> RemoveClusterFromDicFriends(Dictionary<int, int> cluster, Dictionary<int, List<int>> dicFriends)
        {
            for (int i = 0; i < cluster.Count; i++)
                dicFriends.Remove(cluster.Keys.ElementAt(i));

            return dicFriends;
        }

        static Dictionary<int, int> RecursiveFest(int input, Dictionary<int, int> cluster, Dictionary<int, List<int>> dicFriends, Dictionary<int, int> debts)
        {
            if (!cluster.ContainsKey(input))
            {
                cluster.Add(input, debts[input]);

                for (int i = 0; i < dicFriends[input].Count; i++)
                    cluster = RecursiveFest(dicFriends[input][i], cluster, dicFriends, debts);
            }

            return cluster;
        }

        struct Friendship
        {
            public int X { get; set; }
            public int Y { get; set; }

            public Friendship(int x, int y)
            {
                X = x;
                Y = y;
            }
        }
    }
}
