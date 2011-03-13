connection: connection requestedAccountChangeForUsername: username  password: password  newPassword: newPassword newEmail: newEmail
	| response |
	response _ policy changeUser: username withPassword: password toHavePassword: newPassword andNewEmail: newEmail.
	response allowed ifFalse: [
		^self
			sendError: 'changing account for ', username, ' failed (', response reason, ')'
			onConnection: connection].
		
	self sendMessage: (UMEditedAccount username: username newPassword: newPassword newEmail: newEmail) onConnection: connection