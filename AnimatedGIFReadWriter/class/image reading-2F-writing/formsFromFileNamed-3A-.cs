formsFromFileNamed: fileName 
	| stream |
	stream _ FileStream readOnlyFileNamed: fileName.
	^ self formsFromStream: stream