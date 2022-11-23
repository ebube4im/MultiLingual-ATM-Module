namespace MultiLingual_ATM_Module
{
    public class AccountUser
    {
        public string? FullName { get; set; }
        public string? AccountNumber { get; set; }
        public long CardNumber { get; set; }
        public int CardPin { get; set; }
        public int AccountBalance { get; set; }
        public string AccountType { get; set; }




        public List<AccountUser> GenerateRandomUsers()
        {
            List<AccountUser> newUsersList = new List<AccountUser>()
        {
            new AccountUser(){ FullName = "Ebube Anya", AccountBalance = 50000, AccountNumber="0041529343", CardNumber = 12345678987654321, CardPin= 1234, AccountType = "Savings" },
            new AccountUser(){ FullName = "Chuka Dean", AccountBalance = 20000, AccountNumber="0041529344", CardNumber = 12345678987654322, CardPin= 1233, AccountType = "Current" },
             new AccountUser(){ FullName = "Ella Bella", AccountBalance = 30000, AccountNumber="0041529345", CardNumber = 12345678987654323, CardPin= 1232, AccountType = "Savings" },
              new AccountUser(){ FullName = "Alex King", AccountBalance = 100000, AccountNumber="0041529346", CardNumber = 12345678987654324, CardPin= 1231, AccountType = "Current"},
               new AccountUser(){ FullName = "Onah Ebube", AccountBalance = 500000, AccountNumber="0041529347", CardNumber = 12345678987654325, CardPin= 1230, AccountType = "Savings" }

        };

            return newUsersList;

        }
    }
}
