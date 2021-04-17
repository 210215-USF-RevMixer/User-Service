using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserModels;
using Microsoft.EntityFrameworkCore;

namespace UserDL
{
    /// <summary>
    /// UserRepoDB for modifying UserDB
    /// </summary>
    public class UserRepoDB : IUserRepoDB
    {
        private readonly UserDBContext _context;
        public UserRepoDB(UserDBContext context)
        {
            _context = context;
        }
        //Add a report to the DB
        public async Task<Report> AddReportAsync(Report newReport)
        {
            await _context.Report.AddAsync(newReport);
            await _context.SaveChangesAsync();
            return newReport;
        }
        //Add a user to the DB
        public async Task<User> AddUserAsync(User newUser)
        {
            await _context.User.AddAsync(newUser);
            await _context.SaveChangesAsync();
            return newUser;
        }
        //Delete a report from the DB
        public async Task<Report> DeleteReportAsync(Report report2BDeleted)
        {
            _context.Report.Remove(report2BDeleted);
            await _context.SaveChangesAsync();
            return report2BDeleted;
        }
        //Delete a user from the DB
        public async Task<User> DeleteUserAsync(User user2BDeleted)
        {
            _context.User.Remove(user2BDeleted);
            await _context.SaveChangesAsync();
            return user2BDeleted;
        }
        //Get all reports (in a list)
        public async Task<List<Report>> GetAllReportsAsync()
        {
            return await _context.Report
                .Include(r => r.User)
                .AsNoTracking()
                .ToListAsync();
        }
        //Get report by Id
        public async Task<Report> GetReportByIdAsync(int Id)
        {
            return await _context.Report
                .Include(r => r.User)
                .AsNoTracking()
                .Where(r => r.Id == Id)
                .FirstOrDefaultAsync();
        }
        //Get a user by email 
        public async Task<User> GetUserByEmail(string userEmail)
        {
            return await _context.User
                .Include(u => u.Reports)
                .AsNoTracking()
                .Where(u => u.Email == userEmail)
                .FirstOrDefaultAsync();
        }
        //Get a user by Id
        public async Task<User> GetUserByIDAsync(int Id)
        {
            return await _context.User
                .Include(u => u.Reports)
                .AsNoTracking()
                .Where(u => u.Id == Id)
                .FirstOrDefaultAsync();
        }
        //Get a list of all users
        public async Task<List<User>> GetUsersAsync()
        {
            return await _context.User
                .Include(u => u.Reports)
                .AsNoTracking()
                .ToListAsync();
        }
        //Update a report
        public async Task<Report> UpdateReportAsync(Report report2BUpdated)
        {
            Report oldReport = await _context.Report.Where(r => r.Id == report2BUpdated.Id).FirstOrDefaultAsync();

            _context.Entry(oldReport).CurrentValues.SetValues(report2BUpdated);
            await _context.SaveChangesAsync();
            _context.ChangeTracker.Clear();
            return report2BUpdated;
        }
        //Update a user
        public async Task<User> UpdateUserAsync(User user2BUpdated)
        {
            User oldUser = await _context.User.Where(u => u.Id == user2BUpdated.Id).FirstOrDefaultAsync();

            _context.Entry(oldUser).CurrentValues.SetValues(user2BUpdated);

            await _context.SaveChangesAsync();

            _context.ChangeTracker.Clear();
            return user2BUpdated;
        }
    }
}
