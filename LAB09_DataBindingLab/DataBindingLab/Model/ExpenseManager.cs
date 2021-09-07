using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBindingLab.Model
{
    /// <summary>
    /// Main data model class of the application.
    /// </summary>
    public class ExpenseManager
    {
        public readonly CategoryList Categories = new CategoryList();
        public readonly TransactionList Transactions = new TransactionList();

        public ExpenseManager()
        {
            Categories.Add(new Category() { Name = "Étel", IsLuxury = false });
            Categories.Add(new Category() { Name = "Utazás", IsLuxury = false });
            Categories.Add(new Category() { Name = "Rezsi", IsLuxury = false });
            Categories.Add(new Category() { Name = "Extrák", IsLuxury = true });
            Categories.Add(new Category() { Name = "Bevétel", IsLuxury = false });
        }
    }
}
