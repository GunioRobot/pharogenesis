fromFile: aFileName
	^self fromStream: (FileStream readOnlyFileNamed: aFileName)