secCanListPath: pathName OfSize: pathNameSize
	self export: true.
	self var: #pathName type: 'char *'.
	^self cCode: 'ioCanListPathOfSize(pathName, pathNameSize)'