using System;
using System.Collections.Generic;
using System.Text;

namespace WealthFront
{
    class Constants
    {
        // SQL QUERIES
        // idea table - displays the necessary values from the idea table for the dataGridView
        public static string idea_VIEWTABLEVALUES = @"
            SELECT
            sector AS 'Sector',
            risk_rating AS 'Risk Rating',
            comments AS 'Comments',
            like AS 'Like',
            idea_description AS 'Idea Description' ,
            idea_title AS 'Idea Title'
            FROM idea";

        // idea table - inserts specified values into the database
        // the values with @ get their data from what is passed to them when the method that uses this query is called
        public static string idea_INSERTVALUES = @"
            INSERT
            INTO idea
            (sector, risk_rating, comments, like, idea_description, idea_title)
            VALUES
            (@sectorValue, @riskRatingValue, @commentsValue, @likeValue, @ideaDescriptionValue, @ideaTitleValue)
            ";

        // inserts values the user enters on the registration form into the registrationquery table
        public static string RegistrationQuery_CHECK = @"
            INSERT
            INTO User
            (name, username, password, role, confirm_password, email)
            VALUES
            (@nameValue, @usernameValue, @passwordValue, @roleValue, @confirm_passwordValue, @emailValue)";

        // selects the username and password values in the User table that equal those entered by the user on the login form
        public static string userLogin_CHECK = @"
            SELECT count(*)
            FROM 
            WHERE username = @usernameValue
            AND password = @passwordValue";
    }
}
