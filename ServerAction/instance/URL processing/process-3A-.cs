process: request
	| pieces |
	self checkAuthorization: request.
	pieces _ self parse: request.
	self log: pieces to: request.
	self replyTo: pieces from: request.
