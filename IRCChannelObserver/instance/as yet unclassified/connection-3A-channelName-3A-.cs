connection: anIRCConnection channelName: aString
	connection _ anIRCConnection.
	channel _ connection channelInfo: aString.
	channel subscribe: self.
	chatText _ Text new.