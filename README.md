# MVC Project With DAL(Data Access Layer) And BAL(Business Access Layer)
Firstly, the project contains 3 layers,
1) MVC_Pattern :- It consists controller of main project as well as view section.

2) MVC_Model   :- This solution contains tt class which is created with use of entity framework, basically all the database table class which is useful to access database. 

3) MVC_Repository :- It mainly contain 3 parts,\
                       a) Service :- Define the service interface class which is use to call ServiceContract class.\
                       b) ServiceContract :- It extends service interface class and perform database computational task with use of linq.\
                       c) Entityframework :- Contain .edmx file as entityframework.
# How To Configure

1) Open CollegeDB.sql file into MSSQL Server and run this whole sql file,if you would find any error then remove file location lines in sql file.

2) Check Entityframework in MVC_Repository and change the connection string in app.config file on both MVC_Model as well as MVC_Repository.

3) Change the path of inputfile variable in CollegeModel.tt on MVC_Model.

# How It Works

1) You need any faculty login for student registration. so,add any faculty details in database Or Use,

    - Username : xyz@gmail.com
    - Password : password
    
<img src="https://i.ibb.co/chMCf85/Login.png" width="80%" height="70%"/>

2) In faculty dashboard section you can insert,update and delete the student and its like a single page application(SPA).

<img src="https://i.ibb.co/YLHRmCb/Addstudent.png" width="80%" height="70%"/>

# Conclusion

Here, <b>MVC_Pattern</b> solution work as a <b>BAL(Business Access Layer)</b> with the use of that we can call <b>DAL(Data Access Layer)</b> as <b>MVC_Repository</b> solution.
