﻿using FreshBooks.Api.Staff.Models;

namespace FreshBooks.Api.Staff
{
    public interface IStaffApi : IReadOnlyBasicApi<StaffModel>
    {
        /// <summary>
        /// Call the <c>staff.current</c> method on the Freshbooks API.
        /// </summary>
        /// <returns>The <see cref="StaffModel"/> information of the client used to communicate with Freshbooks</returns>
        StaffModel CallGetCurrent();
    }
}