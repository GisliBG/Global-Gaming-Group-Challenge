**Add Book** 
------
* **URL**

  /api/books

* **Method:**
  
  `POST`
  
* **Data Params**

  ```
  {
	"ISBN": "string",
	"Title": "string",
	"Author": "string",
	"Language": "string",
	"Pages": "string"
  }
  ```
* **Success Response:**

  * **Code:** 200 <br />
    **Content:** 
     ```
    {
    "Id": "Guid",
    "ISBN": "string",
    "Title": "string",
    "Author": "string",
    "Language": "string",
    "Pages": "string"
    }
  ```
* **Error Response:**

  * **Code:** 400 BAD REQUEST <br />
  OR
  * **Code:** 412 PRECONDITION FAILED 


**Get All Books** 
------
* **URL**

  /api/books

* **Method:**
  
  `Get`
  
* **Success Response:**

  * **Code:** 200 <br />
    **Content:** 
  ```
    [
      {
          "id": "594b4472-6bbc-4762-b3b6-1917abb1d728",
          "isbn": "1234566",
          "title": "TEST3",
          "author": "TEST3 AUTHOR",
          "language": "Svenska",
          "pages": "500",
          "price": 100,
          "inStock": 2
      },
      ....
    ]
  ```

**Add User** 
------
* **URL**

  /api/user

* **Method:**
  
  `POST`
  
* **Data Params**

	```
		{
			"Email": "string",
			"Password": "string",
			"FirstName": "string",
			"LastName": "string",
			"Address": "string",
			"Phone": "string"
		}
	```
* **Success Response:**

  * **Code:** 200 <br />
    **Content:** 
	```
		{
			"Id": "Guid",
			"Email": "string",
			"Password": "string",
			"FirstName": "string",
			"LastName": "string",
			"Address": "string",
			"Phone": "string"
		}
	```

* **Error Response:**

  * **Code:** 400 BAD REQUEST <br />
  OR
  * **Code:** 412 PRECONDITION FAILED 

**Get user** 
------
* **URL**

  /api/user/:id

*  **URL Params**

   **Required:**
 
   `id=[guid]`

* **Method:**
  
  `Get`
  
* **Success Response:**

  * **Code:** 200 <br />
    **Content:** 
```
	{
		"id": "Guid",
		"email": "string",
		"password": null,
		"firstName": "string",
		"lastName": "string",
		"address": "string",
		"phone": "string"
	}
```

**Update User** 
------
* **URL**

  /api/user

* **Method:**
  
  `PUT`
  
* **Data Params**

```
	{
		"Id": "Guid",	
		"Email": "string",
		"Password": "string",
		"FirstName": "string",
		"LastName": "string",
		"Address": "string",
		"Phone": "string"
	}
```
* **Success Response:**

  * **Code:** 200 <br />
    **Content:** 

* **Error Response:**

  * **Code:** 400 BAD REQUEST <br />
  OR
  * **Code:** 412 PRECONDITION FAILED 
    
**Delete User** 
------
* **URL**

  /api/user

* **Method:**
  
  `DELETE`
  
* **Data Params**

```
	{
		"Id": "Guid",	
		"Email": "string",
		"Password": "string",
		"FirstName": "string",
		"LastName": "string",
		"Address": "string",
		"Phone": "string"
	}
```
* **Success Response:**

  * **Code:** 200 <br />
    **Content:** 

* **Error Response:**

  * **Code:** 400 BAD REQUEST <br />
  OR
  * **Code:** 412 PRECONDITION FAILED 


    
    
    
    
    
