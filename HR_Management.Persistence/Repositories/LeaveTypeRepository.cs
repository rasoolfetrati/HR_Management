﻿using HR_Management.Application.Persistance.Contracts;
using HR_Management.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace HR_Management.Persistence.Repositories
{
    public class LeaveTypeRepository : GenericRepository<LeaveType>, ILeaveTypeRepository
    {
        private readonly LeaveManagementDbContext context;

        public LeaveTypeRepository(LeaveManagementDbContext context):base(context)
        {
            this.context = context;
        }
    }
}
