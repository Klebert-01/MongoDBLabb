using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LayeredCRUDDemo.Model
{
    internal interface IExpenseDAO
    {
        void Create(ExpenseODM expense);
        List<ExpenseODM> ReadAll();
        ExpenseODM ReadOne(int index);
        void UpdateOne(int id, ExpenseODM expense);
        void Delete(int id);

    }
}
