Feature: ReqResTests	

Scenario: Verify that list of users is returned when Http GET method is called
	Given that ReqRes service is invoked with GET endpoint /api/users?page=2
	Then the statuscode for GET is equal to OK
	And the response description for GET is equal to OK
	And the list of users are returned as below:
	| id | first_name | last_name | avatar                                                              |
	| 4  | Eve        | Holt      | https://s3.amazonaws.com/uifaces/faces/twitter/marcoramires/128.jpg |
	| 5  | Charles    | Morris    | https://s3.amazonaws.com/uifaces/faces/twitter/stephenmoon/128.jpg  |
	| 6  | Tracey     | Ramos     | https://s3.amazonaws.com/uifaces/faces/twitter/bigmancho/128.jpg    |
	
Scenario: Verify that a user record can be created
	Given that ReqRes service is invoked with POST endpoint /api/users
	Then the status code for Post is equal to Completed
	And the response description for Post is equal to Created

Scenario: Verify that a user record can be updated
	Given that ReqRes service is invoked with PUT endpoint /api/users/2
	Then the status code for Put is equal to Completed
	And the response description for Put is equal to OK

Scenario: Verify that a user record can be deleted
	Given that ReqRes service is invoked with DELETE endpoint /api/users/2
	Then the statuscode for DELETE is equal to NoContent
	And the response description for DELETE is equal to No Content 