addDirectory: aFileName as: anotherFileName
	| newMember |
	newMember _ self memberClass newFromDirectory: aFileName.
	self addMember: newMember.
	newMember localFileName: anotherFileName.
	^newMember