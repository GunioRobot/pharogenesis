log: aString 
	self logStream
		ifNotNil: [self logStream cr; show: '[' , self className , '] ' , aString]