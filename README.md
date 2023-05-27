# ApiAssessment
# Challenge: 
  XYZ Hotels needs a comprehensive API Core Project that enables customers to make reservations, hotel staff to manage room availability, and provides secure access through JWT token authentication. Additionally, the project should handle the one-to-many relationship between hotels and rooms, where each hotel can have multiple rooms.
  
# Db schema of my idea:
![image](https://github.com/vasanthabalanm/ApiAssessment/assets/127307497/b0513d41-5a5b-49be-88f2-98ca18ae45f3)

Here->
  User table for        -> Owner can perform CRUD using Authentication
  HotelAdmins table for -> Only Hotel Admin can Hold data between customers and hotels
  
# Objectives:
  1.CRUD Operations           -> Done in All table
  2. Filtering                -> It is done in Hoteldetails filter api
  3. Count Functionality      -> It is done in Hoteldetails count api
  4. JWT Token Authentication -> It is done for both Owner and hotelAdmin to create a separate controller to manage and generate token for                                  their flow.
  5. One-to-Many Relationship -> HotelDetails table:
                                     Primary key: HotelId
                                 HotelAdmin table:
                                     Primary key: RoomId
                                     Foreign key: HotelId (referencing the HotelId column in the HotelDetails table)
                                  which statify the each hotelid contains multiple rooms(one to many).
  6. Repository Pattern       ->![image](https://github.com/vasanthabalanm/ApiAssessment/assets/127307497/741603db-020f-4017-9cee-9ce21be528a0)
  7. For Code First Approach
                                step 1 ->install necessary package(CF),JWT
                                step 2 ->Create Model(entities)
                                step 3 ->Create Date(Dbcontext)
                                step 4 ->Connection string to Create DB
                                step 5 ->Add migration and update
                                step 6 ->Add controller
                                step 7 ->Add services to Encapsulate the code(Interface,service class)
                                step 8 ->Create AuthModel for Authentication
                                step 9 ->then do step3,step4,step5,step6
                                step 10->After created, which are the controller should be authenticate add [Authorize Role="owner")] /                                            [Authorize Role="staff")]  
                                
                             



