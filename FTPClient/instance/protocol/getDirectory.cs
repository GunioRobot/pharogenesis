getDirectory
	| dirList |
	self openPassiveDataConnection.
	self sendCommand: 'LIST'.
	dirList _ self getData.
	self checkResponse.
	self checkResponse.
	^dirList
