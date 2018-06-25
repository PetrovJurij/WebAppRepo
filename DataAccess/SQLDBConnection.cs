using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Sql;
using System.Data.SqlClient;
using Entities;

namespace DataAccess
{
    public class SQLDBConnection
    {
        
        private static string SELECT_VOTES_COUNT_BY_ID_AND_BY_IP = "SELECT * FROM VoteView " +
                                                                   "WHERE Company_Id = {0} and User_IP = {1}";
        private static string SELECT_USER_BY_IP_AND_HASH = "Select Users_Id, Users_UserName, Users_IP, UserType.UserType from Users " +
                                                           "INNER JOIN UserType ON Users.Users_Type=UserType.UserType_Id";
        private static string INSERT_USER = "INSERT INTO Users(Users_UserName, Users_IP , Users_Type, User_Pass)" +
                                            "VALUES ({0},{1},{2},{3})";
        private static string INSERT_VOTE = "INSERT INTO Vote(Voted_User,Voted_Company,Vote_Comentary,Vote_Weight) " +
                                            "VALUES ({0},{1},{2},{3})";


        SqlConnection sqlcon;
        public SQLDBConnection()
        {
            SqlConnectionStringBuilder cs = new SqlConnectionStringBuilder();
            cs.DataSource = @"WS-YPETROV\SQLEXPRESS";
            cs.InitialCatalog = "VotingDB";
            cs.IntegratedSecurity = true;
            sqlcon = new SqlConnection(cs.ConnectionString);
            

            try
            {
                sqlcon.Open();
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            finally
            {
                sqlcon.Close();
            }

        }






        public bool UserVote(int Company_Id,User User_IP, string Vote_Comantary, decimal Vote_Weight)
        {
            bool result = true;
            String SelectVote = String.Format(SELECT_VOTES_COUNT_BY_ID_AND_BY_IP,User_IP,Company_Id);
            String InsertVote = String.Format(INSERT_VOTE, Company_Id, User_IP, Vote_Comantary, Vote_Weight);
            String SelectUser = String.Format(SELECT_USER_BY_IP_AND_HASH,User_IP);
            String InsertUser = String.Format(INSERT_USER, "Anonymous", User_IP, 1, "null");
            SqlDataReader readerVote, readerUser;
            SqlCommand SelectVoteCommand, InsertVoteCommand, SelectUserCommand, InsertUserCommand;

            try
            {
                sqlcon.Open();
                SelectVoteCommand = new SqlCommand(SelectVote, sqlcon);
                InsertVoteCommand = new SqlCommand(InsertVote, sqlcon);
                SelectUserCommand = new SqlCommand(SelectUser, sqlcon);
                InsertUserCommand = new SqlCommand(InsertUser, sqlcon);

                readerUser = SelectUserCommand.ExecuteReader();
                if (!readerUser.HasRows)
                {
                    readerUser.Close();
                    InsertUserCommand.ExecuteNonQuery();
                }

                readerVote = SelectVoteCommand.ExecuteReader();
                readerVote.Read();

                if (Convert.ToInt32(readerVote.GetValue(0)) != 0)
                    result = false;
                else
                {
                    InsertVoteCommand.ExecuteNonQuery();
                }

                InsertVoteCommand.Dispose();
                SelectVoteCommand.Dispose();
                readerVote.Close();

            }
            catch (SqlException ex)
            {
                throw ex;
            }
            finally
            {
                if (sqlcon.State == System.Data.ConnectionState.Open)
                    sqlcon.Close();
            }

            return result;
        }


        private User WrapUser(SqlDataReader userReader)
        {
            User result = new User();
            result.User_Id = Convert.ToInt32(userReader.GetValue(0));

            return result;
        }

    }
}
