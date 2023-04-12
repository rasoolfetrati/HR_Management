using HR_Management.Application.Contracts.Persistence;
using HR_Management.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HR_Management.Persistence.Repositories
{
    public class LeaveAllocationRepository : GenericRepository<LeaveAllocation>, ILeaveAllocationRepository
    {
        private readonly LeaveManagementDbContext context;

        public LeaveAllocationRepository(LeaveManagementDbContext context) : base(context)
        {
            this.context = context;
        }

        public async Task<List<LeaveAllocation>> GetLeaveAllocationsListWithDetails()
        {
            var leaveAllocations = await context.LeaveAllocations
               .Include(l => l.LeaveType)
               .ToListAsync();
            return leaveAllocations;
        }

        public async Task<LeaveAllocation> GetLeaveAllocationWithDetails(int Id)
        {
            var leaveAllocation = await context.LeaveAllocations
             .Include(l => l.LeaveType)
             .FirstOrDefaultAsync(t => t.Id == Id);
            return leaveAllocation;
        }
    }
}
