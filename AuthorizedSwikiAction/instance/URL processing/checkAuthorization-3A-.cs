checkAuthorization: request
	^ authorizer ifNotNil: [authorizer user: request userID].
