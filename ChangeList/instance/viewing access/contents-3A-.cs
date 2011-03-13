contents: aString
	listIndex = 0
		ifTrue: [self changed: #flash. ^ false]
		ifFalse: [Cursor read showWhile: [(changeList at: listIndex) fileIn].
				^ true]