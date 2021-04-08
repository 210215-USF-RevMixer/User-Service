using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserModels;

namespace UserDL
{
    public interface IUserRepoDB
    {
        //Get all users
        Task<List<User>> GetUsersAsync();
        //Get user by user email
        Task<User> GetUserByEmail(string userEmail);
        //Add user to DB
        Task<User> AddUserAsync(User newUser);
        //Delete user from DB
        Task<User> DeleteUserAsync(User user2BDeleted);
        //Get user by Id
        Task<User> GetUserByIDAsync(int Id);
        //Update user
        Task<User> UpdateUserAsync(User user2BUpdated);
        //Get report by id
        Task<Report> GetReportByIdAsync(int Id);
        //Get all reports
        Task<List<Report>> GetAllReportsAsync();
        //Add report to DB
        Task<Report> AddReportAsync(Report newReport);
        //Delete Report from DB
        Task<Report> DeleteReportAsync(Report report2BDeleted);
        //Update Report
        Task<Report> UpdateReportAsync(Report report2BUpdated);
    }
}
