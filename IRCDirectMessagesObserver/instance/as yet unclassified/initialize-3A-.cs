initialize: aConnection
	connection _ aConnection.
	chatText _ Text new.
	connection subscribeToDirectMessages: self.