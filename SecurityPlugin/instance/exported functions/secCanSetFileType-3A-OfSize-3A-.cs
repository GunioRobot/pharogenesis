secCanSetFileType: fileName OfSize: fileNameSize
	self export: true.
	self var: #fileName type: 'char *'.
	^self cCode: 'ioCanSetFileTypeOfSize(fileName, fileNameSize)'