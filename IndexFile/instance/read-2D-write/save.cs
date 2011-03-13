save
	| dir shortName |
	super save. 
	self logStream close.
	shortName _ FileDirectory localNameFor: filename.
	dir _ FileDirectory forFileName: filename.
	dir deleteFileNamed: shortName , '.log' ifAbsent: []