﻿using FluentValidation;
using HR_Management.Application.Contracts.Persistence;
using System;
using System.Collections.Generic;
using System.Text;

namespace HR_Management.Application.DTOs.LeaveAllocation.Validators
{
    public class CreateLeaveAllocationDtoValidator:AbstractValidator<CreateLeaveAllocationDto>
    {
        private readonly ILeaveAllocationRepository _leaveAllocationRepository;

        public CreateLeaveAllocationDtoValidator(ILeaveAllocationRepository leaveAllocationRepository)
        {
            _leaveAllocationRepository = leaveAllocationRepository;
            Include(new ILeaveAllocationDtoValidator(_leaveAllocationRepository));
        }
    }
}
