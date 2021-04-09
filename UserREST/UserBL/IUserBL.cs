using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserModels;

namespace UserBL
{
    public interface IUserBL
    {
        //Get all users
        Task<List<User>> GetUsersAsync();
        //Get User By Email
        Task<User> GetUserByEmail(string userEmail);
        //Get user by ID
        Task<User> GetUserByIDAsync(int id);
        //Add a user
        Task<User> AddUserAsync(User newUser);
        //Update a user
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
