getFileNamed: remoteFileName
	| data |
	self openPassiveDataConnection.
	self sendCommand: 'RETR ', remoteFileName.
	[self checkResponse]
		on: TelnetProtocolError
		do: [:ex |
			self closeDataSocket.
			ex pass].
	data _ self getData.
	self checkResponse.
	^data
