secCanDeletePath: dirName OfSize: dirNameSize
	self export: true.
	self var: #dirName type: 'char *'.
	^self cCode: 'ioCanDeletePathOfSize(dirName, dirNameSize)'