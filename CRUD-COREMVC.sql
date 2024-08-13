Create table Student(          
    Id int IDENTITY(1,1) NOT NULL,          
    FirstName varchar(50) NOT NULL,          
    LastName varchar(50) NOT NULL,  
    Email varchar(30) NOT NULL,   
    Mobile varchar(20) NOT NULL,  
    Address varchar(220)  NULL,         
) 
select * from student;

Create procedure spAddStudent          
(          
    @FirstName VARCHAR(50),           
    @LastName VARCHAR(50),          
    @Email VARCHAR(30),          
    @Mobile VARCHAR(20),  
    @Address VARCHAR(220)          
)          
as           
Begin           
    Insert into Student (FirstName,LastName,Email, Mobile,Address)           
    Values (@FirstName,@LastName,@Email, @Mobile,@Address)           
End 


Create procedure spUpdateStudent            
(            
    @Id INTEGER ,          
    @FirstName VARCHAR(50),           
    @LastName VARCHAR(50),          
    @Email VARCHAR(30),          
    @Mobile VARCHAR(20),  
    @Address VARCHAR(220)            
)            
as            
begin            
   Update Student             
   set FirstName=@FirstName,            
   LastName=@LastName,            
   Email=@Email,          
   Mobile=@Mobile,   
   Address=@Address            
   where Id=@Id            
End


Create procedure spDeleteStudent           
(            
   @Id int            
)            
as             
begin            
   Delete from Student where Id=@Id            
End  


Create procedure spGetAllStudent        
as        
Begin        
    select *        
    from Student     
    order by Id   
End