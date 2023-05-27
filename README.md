# ApiAssessment
# Challenge: 
   XYZ Hotels needs a comprehensive API Core Project that enables customers to make reservations, hotel staff to manage room availability, and provides secure access through JWT token authentication. Additionally, the project should handle the one-to-many relationship between hotels and rooms, where each hotel can have multiple rooms.
  
# Db schema of my idea:
  ![image](https://github.com/vasanthabalanm/ApiAssessment/assets/127307497/b0513d41-5a5b-49be-88f2-98ca18ae45f3)

### Here->
   User table for        -> Owner can perform CRUD using Authentication <br>
   HotelAdmins table for -> Only Hotel Admin can Hold data between customers and hotels
  
# Objectives:
  1.CRUD Operations           -> Done in All table <br>
  2. Filtering                -> It is done in Hoteldetails filter api <br>
  3. Count Functionality      -> It is done in Hoteldetails count api <br>
  4. JWT Token Authentication -> It is done for both Owner and hotelAdmin to create a separate controller to manage and generate token for their flow. <br>
  5. One-to-Many Relationship -> HotelDetails table: <br>
                                     Primary key: HotelId <br>
                                 HotelAdmin table: <br>
                                     Primary key: RoomId <br>
                                     Foreign key: HotelId (referencing the HotelId column in the HotelDetails table) ,
                                  which statify the each hotelid contains multiple rooms(one to many). <br>
  6. # Repository Pattern       ->![image](https://github.com/vasanthabalanm/ApiAssessment/assets/127307497/741603db-020f-4017-9cee-9ce21be528a0) <br>
  7. For Code First Approach <br>
                                step 1 ->install necessary package(CF),JWT <br>
                                step 2 ->Create Model(entities) <br>
                                step 3 ->Create Date(Dbcontext) <br>
                                step 4 ->Connection string to Create DB <br>
                                step 5 ->Add migration and update <br>
                                step 6 ->Add controller <br>
                                step 7 ->Add services to Encapsulate the code(Interface,service class) <br>
                                step 8 ->Create AuthModel for Authentication <br>
                                step 9 ->then do step3,step4,step5,step6 <br>
                                step 10->After created, which are the controller should be authenticate add [Authorize Role="owner")] /                                            [Authorize Role="staff")]  
                                
                             



