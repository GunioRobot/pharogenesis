openFileNamed: fileName
	file := (MultiByteFileStream readOnlyFileNamed: fileName)
		ascii;
		wantsLineEndConversion: true;
		yourself