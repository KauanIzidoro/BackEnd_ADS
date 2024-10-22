public class AccountCompareName : IComparer<Account>
{
    public int Compare(Account x, Account y)
    {
        if(x==null || y==null)
        {
            return -2; //error
        }
        return x.Name.ComporeTo(y.Name);
    }
}