addFile: aFileName as: anotherFileName
	| newMember |
	newMember _ self memberClass newFromFile: aFileName.
	self addMember: newMember.
	newMember localFileName: anotherFileName.
	^newMember