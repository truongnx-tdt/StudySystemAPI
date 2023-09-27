﻿using StudySystem.Data.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudySystem.Data.EF.Repositories.Interfaces
{
    public interface IUserRepository : IRepository<UserDetail>
    {
        Task<bool> IsUserExists(string userId);
        Task InsertUserDetails(UserDetail userDetail);
        Task UpdateStatusActiveUser(string userID);
    }
}