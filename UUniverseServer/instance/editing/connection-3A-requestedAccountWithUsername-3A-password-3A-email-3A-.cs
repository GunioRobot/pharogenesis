connection: connection requestedAccountWithUsername: username  password: password  email: email 
	| response |
	response _ policy addUser: username withPassword: password andEmail: email.
	response allowed ifFalse: [
		self
			sendError: 'adding account for ', username, ' failed (', response reason, ')'
			onConnection: connection].