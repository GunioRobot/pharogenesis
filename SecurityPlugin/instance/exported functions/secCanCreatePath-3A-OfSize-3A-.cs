secCanCreatePath: dirName OfSize: dirNameSize
	self export: true.
	self var: #dirName type: 'char *'.
	^self cCode: 'ioCanCreatePathOfSize(dirName, dirNameSize)'