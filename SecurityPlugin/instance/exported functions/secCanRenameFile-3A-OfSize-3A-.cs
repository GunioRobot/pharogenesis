secCanRenameFile: fileName OfSize: fileNameSize
	self export: true.
	self var: #fileName type: 'char *'.
	^self cCode: 'ioCanRenameFileOfSize(fileName, fileNameSize)'