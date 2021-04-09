using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserModels;
using UserDL;

namespace UserBL
{
    /// <summary>
    /// Business logic for User Service
    /// </summary>
    public class UserBL : IUserBL
    {
        private IUserRepoDB _repo;
        public UserBL(IUserRepoDB repo)
        {
            _repo = repo;
        }
        //Add a report
        public async Task<Report> AddReportAsync(Report newReport)
        {
            return await _repo.AddReportAsync(newReport);
        }
        //Add a user
        public async Task<User> AddUserAsync(User newUser)
        {
            return await _repo.AddUserAsync(newUser);
        }
        //Delete a report
        public async Task<Report> DeleteReportAsync(Report report2BDeleted)
        {
            return await _repo.DeleteReportAsync(report2BDeleted);
        }
        //Get all reports
        public async Task<List<Report>> GetAllReportsAsync()
        {
            return await _repo.GetAllReportsAsync();
        }
        //Get report by Id
        public async Task<Report> GetReportByIdAsync(int Id)
        {
            return await _repo.GetReportByIdAsync(Id);
        }
        //Get user by email
        public async Task<User> GetUserByEmail(string userEmail)
        {
            User user2Return = await _repo.GetUserByEmail(userEmail);

            if (user2Return == null) //add user to DB if they do not exist
            {
                user2Return = new User();
                user2Return.Email = userEmail;
                return await _repo.AddUserAsync(user2Return);
            }
            else //otherwise just return the found user
            {
                return user2Return;
            }
        }
        //Get user by Id
        public async Task<User> GetUserByIDAsync(int Id)
        {
            return await _repo.GetUserByIDAsync(Id);
        }
        //Get all users
        public async Task<List<User>> GetUsersAsync()
        {
            return await _repo.GetUsersAsync();
        }
        //Update a report
        public async Task<Report> UpdateReportAsync(Report report2BUpdated)
        {
            return await _repo.UpdateReportAsync(report2BUpdated);
        }
        //Update a user
        public async Task<User> UpdateUserAsync(User user2BUpdated)
        {
            return await _repo.UpdateUserAsync(user2BUpdated);
        }
    }
}
