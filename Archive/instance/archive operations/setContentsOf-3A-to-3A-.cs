setContentsOf: aMemberOrName to: aString
	| newMember oldMember |
	oldMember _ self member: aMemberOrName.
	newMember _ (self memberClass newFromString: aString named: oldMember fileName)
		copyFrom: oldMember.
	self replaceMember: oldMember with: newMember.