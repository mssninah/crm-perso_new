using System.Collections.Generic;

namespace Newapp.Models
{
    public class DashBoard2Model
{
    public int CustomerCount { get; set; }
    public decimal TotalBudget { get; set; }
    public decimal TotalExpenses { get; set; }
    public int LeadCount { get; set; }
    public int TicketCount { get; set; }
    public List<string> AverageExpenseLabels { get; set; }
    public List<decimal> AverageExpenseValues { get; set; }
    public List<string> CumulativeBudgetsLabels { get; set; }
    public List<decimal> CumulativeBudgetsValues { get; set; }
}

}