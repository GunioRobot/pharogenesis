addString: aString as: aFileName
	| newMember |
	newMember _ self memberClass newFromString: aString named: aFileName.
	self addMember: newMember.
	newMember localFileName: aFileName.
	^newMember