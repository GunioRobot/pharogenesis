saveTo: filename
	|f|
	f _ ReferenceStream fileNamed: filename.
	f nextPut: self map.
	f close.