fileContents: serverFileRef
	^(FileStream fileNamed: (ServerAction serverDirectory) , serverFileRef)
	 contentsOfEntireFile