using HR_Management.Application.Contracts.Persistence;
using HR_Management.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HR_Management.Persistence.Repositories
{
    public class LeaveRequestRepository : GenericRepository<LeaveRequest>, ILeaveRequestRepository
    {
        private readonly LeaveManagementDbContext context;

        public LeaveRequestRepository(LeaveManagementDbContext context) : base(context)
        {
            this.context = context;
        }
        public async Task ChangeApprovalStatus(LeaveRequest leaveRequest, bool? approvalStatus)
        {
            leaveRequest.Approved = approvalStatus;
            context.Entry(leaveRequest).State = EntityState.Modified;
            await context.SaveChangesAsync();
        }

        public async Task<List<LeaveRequest>> GetLeaveRequestsListWithDetails()
        {
            var leaveRequests = await context.LeaveRequests
                .Include(l => l.LeaveType)
                .ToListAsync();
            return leaveRequests;
        }

        public async Task<LeaveRequest> GetLeaveRequestWithDetails(int id)
        {
            var leaveRequest = await context.LeaveRequests
              .Include(l => l.LeaveType)
              .FirstOrDefaultAsync(t => t.Id == id);
            return leaveRequest;
        }
    }
}
