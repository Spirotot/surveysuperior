<%@ Application Language="C#" %>

<script runat="server">

    void Application_Start(object sender, EventArgs e) 
    {
        //for a test teacher
        //username: thalverson
        //password: thalv1!
        //for a test student
        //username: Chuck
        //password: chuck1!
        // Code that runs on application startup
                                                    //Application["test"] = "fucking a if this works";
        Application["users"] = new String[1000,1000]/*{
                            {"user","1"},
                            {"user2", "2"}
                           }*/;
        Application["usersCount"] = 0;
        Application["pollsCount"] = 0;
        //name, votes
        //"Michael", "", "1", "", "3"
        //"bob", "", "1", "2", ""

        Application["polls"] = new String[1000,5];/*{
                            {"poll", "answer1", "answer2", "answer3", "answer4"}
                           };*//*
                          * 
                          * 0 question
                          * 1-4answers
                          */
        //"What is your name", "bob", "jordan", "no name", "blow off"
        //"Isn't is a nice day", "Yes", "kinda", "ehh", "suck a rabbit off"
    }
    
    void Application_End(object sender, EventArgs e) 
    {
        //  Code that runs on application shutdown

    }
        
    void Application_Error(object sender, EventArgs e) 
    { 
        // Code that runs when an unhandled error occurs

    }

    void Session_Start(object sender, EventArgs e) 
    {
        // Code that runs when a new session is started

    }

    void Session_End(object sender, EventArgs e) 
    {
        // Code that runs when a session ends. 
        // Note: The Session_End event is raised only when the sessionstate mode
        // is set to InProc in the Web.config file. If session mode is set to StateServer 
        // or SQLServer, the event is not raised.

    }
       
</script>
