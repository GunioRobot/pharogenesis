contents: aString
	listIndex = 0 ifTrue: [self changed: #flash. ^ false].
	lostMethodPointer ifNotNil: [^ self restoreDeletedMethod].
	(changeList at: listIndex) fileIn.
	^ true