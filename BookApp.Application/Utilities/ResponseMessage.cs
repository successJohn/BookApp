using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookApp.Application.Utilities
{
    public class ResponseMessage
    {
        public const string ErrorMessage000 = "USER NOT FOUND!";
        public const string ErrorMessage507 = "INCORRECT USERNAME OR PASSWORD";
        public const string ErrorMessage503 = "ACCOUNT IS LOCKED, CONTACT ADMIN";
        public const string ErrorMessage502 = "EMAIL NOT CONFIRMED, KINDLY CONFIRM YOUR ACCOUNT";
        public const string ErrorMessage504 = "INCORRECT USERNAME";
        public const string ErrorMessage510 = "ACCESS DENIED";
        public const string ErrorMessage511 = "ACCOUNT CONFIRMATION FAILED";
        public const string ErrorMessage512 = "CONFIRMATION TOKEN INVALID";
        public const string ErrorMessage513 = "CONFIRMATION EMAIL INVALID";
        public const string ErrorMessage500 = "REFRESH TOKEN NOT FOUND!";
        public const string ErrorMessage505 = "ACCOUNT ALREADY LOCKED";
        public const string ErrorMessage506 = "ACCOUNT LOCKED";
        public const string ErrorMessage508 = "ACCOUNT IS NOT LOCKED";

        public const string AccountUnlocked = "ACCOUNT UNLOCKED!";
        public const string SuccessfullyUpdatedClaim = "PERMMISSION UPDATED";
        public const string PasswordChanged = "PASSWORD CHANGED SUCCESSFULLY!";
        public const string PasswordChangedFailure = "PASSWORD CHANGED FAILED";
        public const string AccountAlreadyConfirmed = "ACCOUNT HAS ALREADY BEEN CONFIRMED, YOU CAN NOW LOG IN!";
        public const string AccountConfirmed = "ACCOUNT SUCCESSFULLY CONFIRMED!";
        public const string AccountCreationFailure = "ACCOUNT CREATION FAILED";
        public const string AccountCreationSuccess = "ACCOUNT CREATED SUCCESSFULLY";
        public const string PasswordResetCodeSent = "PASSWORD RESET CODE SENT!";
        public const string RemovePermmissionFailure = "ERROR REMOVING PERMISSION";
        public const string AddPermmissionFailure = "ERROR ADDING PERMISSION";
        public const string UserTypeFailure = "USER TYPE NOT ADMIN";
        public const string AddToRoleFailure = "FAILED TO ADD USER TO ROLE";
        public const string SuccessMessage000 = "SUCCESSFUL";
        public const string FailureMessage000 = "FAILED";
    }
}
