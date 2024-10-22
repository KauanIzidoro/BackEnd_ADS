using System;

public class Program
{
    public static void Main()
    {
        Account account1 = new Account(221, "Kauan");
        Account account2 = new Account(222, "Izidoro");
        Account account3 = new Account(220, "Henrique");

        HashSet<Account> accounts = new HashSet<Account>();
        accounts.Add(account1);
        accounts.Add(account1);
        accounts.Add(account2);
        accounts.Add(account2);
        accounts.Add(account3);
        accounts.Add(account3);

        // accounts.Sort();
        // accounts.Sort(new AccountCompareName());




        foreach(Account a in accounts)
        {
            Console.WriteLine(a);
        }
    }
}