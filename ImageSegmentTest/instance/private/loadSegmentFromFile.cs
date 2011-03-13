loadSegmentFromFile
	| stream |
	stream := FileStream oldFileNamed: self fileName.
	^ stream fileInObjectAndCode install arrayOfRoots first