﻿namespace Bazario.AspNetCore.Shared.Contracts.UserRegistered
{
    public sealed record UserRegisteredForUserServiceEvent(
        Guid UserId,
        string Email,
        string FirstName,
        string LastName,
        DateOnly BirthDate,
        string PhoneNumber);
}
