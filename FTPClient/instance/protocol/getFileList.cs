getFileList
	| dirList |
	self openPassiveDataConnection.
	self sendCommand: 'NLST'.
	dirList _ self getData.
	self checkResponse.
	self checkResponse.
	^dirList
