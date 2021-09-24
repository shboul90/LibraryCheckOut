# LibraryCheckOut
GroupFinal EF

Welcome to Library Check Out API!

There are three (3) featured classes within this API:
1. Member
2. Media
3. CheckOut

For each data class referenced above the following entities exist:
1. Member:
        
        int Member_id
        
        Guid OwnerId
        
        string FirstName
        
        string LastName
        
        string StreetAddress
        
        string City
        
        string State
        
        string Zip
        
        string PhoneNumber
        
        DateTime DateOfMembership
        
        RatingTypes MembershipRating

        DateTimeOffset CreatedUtc

        DateTimeOffset? ModifiedUtc

2. Media:
	int Media_Id

	MediaTypes MediaType

	string Title

	string Author

	DateTime YearReleased

	GenreTypes Genre

	RatingTypes Rating

	int Quantity

	int InstockQuantity

	DateTime DateAdded

	DateTime LastUpdated

	string AddedBy

	string LastUpdatedBy

	virtual ICollection<Checkout> CheckoutCollection

3. Checkout:
        int Checkout_Id
        
        Guid ID

        DateTime CheckoutDate

        DateTime CheckoutDueDate
        {
                DateTime dueDate = CheckoutDate.AddDays(7);
                return dueDate;
        }

        [ForeignKey(nameof(Member))]
        int Member_id

        virtual ICollection<Media> MediaCollection

        int TotalNumberOfItems

--------------------------------------------------------------------------------------------------------

Models: 
The models can be found within the API Help directory:
https://localhost:44389/Help 
**Your localhost address may differ.

Media has nine (9) operational API functions:
POST api/Media
(Create Media)	

GET api/Media	
(Get All Media)

GET api/Media/Genre?genreType={genreType}	
(Get Media by genre type)

GET api/Media/Author?author={author}	
(Get Media by author)

GET api/Media/Type?type={type}	
(Get Media by media type)

GET api/Media/Rating?rating={rating}	
(Get Media by rating)

GET api/Media/YearReleasedRange?from={from}&to={to}	
(Get Media by date range)

PUT api/Media	
(Update Media)

DELETE api/Media?mediaId={mediaId}	
(Delete Media)

Checkout has six (6) operational API functions:
POST api/Checkout	
(Create Checkout)

GET api/Checkout	
(Get all Checkouts)

GET api/Checkout?lastName={lastName}	
(Get Checkout by lastName)

GET api/Checkout?mediaType={mediaType}	
(Get Checkout by Media Type)

GET api/Checkout?mediaTitle={mediaTitle}	
(Get Checkout by Media Title)

GET api/Checkout?dateTime={dateTime}	
(Get Checkout by date)


Member has five (5) operational API functions:
GET api/Member	
(Get all Members)

GET api/Member/{id}	
(Get Member by ID)

POST api/Member	
(Create Member)

PUT api/Member	
(Update Member)

DELETE api/Member/{id}	
(Delete Member)

--------------------------------------------------------------------------------------------------------

Three (3) Enum categories exist:

GenreTypes:
        Action = 0,
        Adventure = 1,
        Comedy = 2,
        Crime_and_Mystery = 3,
        Fantasy = 4,
        Historical = 5,
        Horror = 6,
        Romance = 7,
        Satire = 8,
        Fiction = 9,
        Cyberpunk_and_derivatives = 10,
        Speculative = 11,
        Thriller = 12,
        Western = 13,
        Other = 14

MediaTypes
        Book = 1,
        DVD = 2,
        Audio_Book = 3,
        Other = 4

RatingTypes
        Children_All_Ages = 1,
        Teen_13_Plus = 2,
        Adult_18_Plus = 3
