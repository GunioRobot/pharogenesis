process: request
	self checkAuthorization: request.
	^(super process: request).