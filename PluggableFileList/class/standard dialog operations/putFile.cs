putFile

	| result |
	result _ self getFilePathNameWithExistenceCheck.
	^result ifNotNil: 
		[FileDirectory deleteFilePath: result.
		 FileStream newFileNamed: result]