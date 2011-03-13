processRawMessage: aStringArray  fromConnection: connection
	| message |
	message _ UMessage fromStringArray: aStringArray.
	message applyToServer: self forConnection: connection.
	self logMessage: message.
	