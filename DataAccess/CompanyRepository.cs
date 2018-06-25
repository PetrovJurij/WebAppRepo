using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;

namespace DataAccess
{
    public class CompanyRepository : ICompanyRepository
    {
        private SqlConnection _sqlcon;
        private readonly string SELECT_LIST_OF_COMPANIES_BY_BATCHES_FROM_DB= 
            "SELECT  Company_Id, CompanyName, CompanyDesc, CompanyRating, NumberOfVotes " +
            "FROM (SELECT ROW_NUMBER() OVER (ORDER BY CompanyRating desc) AS RowNum, * " +
            "FROM Companies) " +
            "AS RowConstrainedResult " +
            "WHERE RowNum >= {0} AND RowNum<= {1} " +
            "ORDER BY RowNum";
        public readonly string SELECT_COMPANY_COUNT = "SELECT Count(*) FROM Companies";
        public readonly string SELECT_COMPANY_BY_ID = "SELECT Company_Id, CompanyName, CompanyDesc, CompanyRating, NumberOfVotes " +
                                                     "FROM Companies WHERE Company_Id = {0}";

        public CompanyRepository(SqlConnection sqlcon)
        {
            _sqlcon = sqlcon;
        }

        public CompanyRepository()
        {
            SqlConnectionStringBuilder cs = new SqlConnectionStringBuilder();
            cs.DataSource = @"WS-YPETROV\SQLEXPRESS";
            cs.InitialCatalog = "VotingDB";
            cs.IntegratedSecurity = true;
            _sqlcon = new SqlConnection(cs.ConnectionString);


            try
            {
                _sqlcon.Open();
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            finally
            {
                _sqlcon.Close();
            }

        }

        public List<Company> GetCompaniesList(int page,int num)
        {
            String s = String.Format(SELECT_LIST_OF_COMPANIES_BY_BATCHES_FROM_DB, (page - 1) * num, page * num);
            List<Company> companiesRep = new List<Company>();
            Company nextCompany;
            SqlDataReader reader;
            SqlCommand command;
            try
            {
                _sqlcon.Open();
                command = new SqlCommand(s, _sqlcon);
                reader = command.ExecuteReader();
                while (reader.Read())
                {
                    nextCompany = WrapCompany(reader);
                    companiesRep.Add(nextCompany);
                }

                reader.Close();
                command.Dispose();
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            finally
            {
                if (_sqlcon.State == System.Data.ConnectionState.Open)
                {
                    _sqlcon.Close();
                }
            }

            return companiesRep;
        }

        public List<Company> GetCompanyList(int page, int numberOfCompanies)
        {
            String s = String.Format(SELECT_LIST_OF_COMPANIES_BY_BATCHES_FROM_DB, (page - 1) * numberOfCompanies, page * numberOfCompanies);
            List<Company> companiesRep = new List<Company>();
            Company nextCompany;
            SqlDataReader reader;
            SqlCommand command;

            try
            {
                _sqlcon.Open();
                command = new SqlCommand(s, _sqlcon);
                reader = command.ExecuteReader();
                while (reader.Read())
                {
                    nextCompany = WrapCompany(reader);
                    companiesRep.Add(nextCompany);
                }

                reader.Close();
                command.Dispose();
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            finally
            {
                if (_sqlcon.State == System.Data.ConnectionState.Open)
                {
                    _sqlcon.Close();
                }
            }

            return companiesRep;
        }

        public Company GetCompany(int Id)
        {
            String s = String.Format(SELECT_COMPANY_BY_ID, Id);
            Company result = new Company();
            SqlDataReader reader;
            SqlCommand command;

            try
            {
                _sqlcon.Open();
                command = new SqlCommand(s, _sqlcon);
                reader = command.ExecuteReader();
                reader.Read();
                result = WrapCompany(reader);

            }
            catch (SqlException ex)
            {
                throw ex;
            }
            finally
            {
                if (_sqlcon.State == System.Data.ConnectionState.Open)
                    _sqlcon.Close();
            }

            return result;
        }

        public int GetCompanyCount()
        {
            int result = 0;
            SqlDataReader reader;
            SqlCommand command;

            try
            {
                _sqlcon.Open();
                command = new SqlCommand(SELECT_COMPANY_COUNT, _sqlcon);
                reader = command.ExecuteReader();

                reader.Read();
                result = Convert.ToInt32(reader.GetValue(0));

                reader.Close();
                command.Dispose();
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            finally
            {
                _sqlcon.Close();
            }

            return result;
        }


        private Company WrapCompany(SqlDataReader companyReader)
        {
            Company result = new Company();
            result.CompanyId = Convert.ToInt32(companyReader.GetValue(0));
            result.CompanyName = Convert.ToString(companyReader.GetValue(1));
            result.CompanyDesc = Convert.ToString(companyReader.GetValue(2));
            result.Companyrating = Convert.ToDecimal(companyReader.GetValue(3));
            result.NumberOfVotes = Convert.ToInt32(companyReader.GetValue(4));

            return result;
        }
    }
}
