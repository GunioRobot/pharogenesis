secCanOpenFile: fileName OfSize: fileNameSize Writable: writeFlag
	self export: true.
	self var: #fileName type: 'char *'.
	^self cCode: 'ioCanOpenFileOfSizeWritable(fileName, fileNameSize, writeFlag)'