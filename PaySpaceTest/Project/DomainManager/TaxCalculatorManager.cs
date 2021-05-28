
using DomainManager.Interfaces;
using DomainManager.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace DomainManager
{
    public class TaxCalculatorManager : ITaxCalculator
    {
        RatesManager _rates = new RatesManager();

        /// <summary>
        /// calculates the tax given the rate and income
        /// </summary>summary>
        /// <param name="rate"></param><param name="income"></param>
        /// <returns>Tax ammount</returns>
        public decimal Calculate(decimal rate, decimal income)
        {
            return decimal.Parse((rate * income).ToString("#.00"));
        }
        /// <summary>
        /// Gets rates of for user and then calculates the tax given the rate and annualincome
        /// then calls the saving of the calculated tax and relevant info to the database
        /// </summary>summary>
        /// <param name="date"></param>
        /// <returns>progress rate</returns>
        public decimal SaveTaxData(TaxModel data)
        {
            try
            {
                decimal rate = _rates.getRates(data.PostalCode, data.AnnualIncome);
                bool result;
                if (rate > 0 && rate < 1)
                {
                    decimal tax = Calculate(rate, data.AnnualIncome);
                    result = SaveTaxRecord(data, tax);
                    return tax;
                }
                else
                { 
                    result = SaveTaxRecord(data, rate);
                    return rate;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// Saves Tax Record to database
        /// </summary>summary>
        /// <param name="data"></param><param name="tax"></param>
        /// <returns>true if successful</returns>
        public bool SaveTaxRecord(TaxModel data, decimal tax)
        {
            try
            {
                int savedId = 0;
                string connection = "Data Source=.\\SQLLOCALDB;initial catalog=TaxCalculator;integrated security=True;";
                using (SqlConnection conn = new SqlConnection(connection))
                {
                    using (SqlCommand command = new SqlCommand("dbo.resources_saveCalculatedTaxHistory", conn))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.Add("@annualIncome", SqlDbType.Decimal).Value = data.AnnualIncome;
                        command.Parameters.Add("@calculatedTax", SqlDbType.Decimal).Value = tax;
                        command.Parameters.Add("@dateCalculated", SqlDbType.DateTime).Value = DateTime.Now;
                        command.Parameters.Add("@postalCode", SqlDbType.NVarChar).Value = data.PostalCode;
                        SqlParameter retParam = command.Parameters.Add("@ReturnStatus", SqlDbType.Int);
                        retParam.Direction = ParameterDirection.ReturnValue;
                        conn.Open();
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            reader.Close();
                            savedId = (int)retParam.Value;
                        }
                    }
                    if (savedId > 0)
                        return true;
                    else
                        return false;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
           
        }
    }
}
