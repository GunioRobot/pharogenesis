readTape: fileName 
	| file |
	self writeCheck.
	(FileStream isAFileNamed: fileName) ifFalse: [^ nil].
	file _ FileStream oldFileNamed: fileName.
	tape _ self readFrom: file.
	file close.
	saved _ true  "Still exists on file"