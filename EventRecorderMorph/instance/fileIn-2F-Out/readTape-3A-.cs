readTape: fileName 
	| file |
	self writeCheck.
	(FileStream isAFileNamed: fileName) ifFalse: [^ nil].
	file _ FileStream oldFileNamed: fileName.
	file peek isDigit
		ifTrue: [self readFrom: file. file close]
		ifFalse: [tape _ file fileInObjectAndCode].
	saved _ true  "Still exists on file"