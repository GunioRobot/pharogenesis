setNameTo: aString
	super setNameTo: aString.
	(submorphs size > 0 and: [submorphs first isKindOf: StringMorph])
		ifTrue:
			[submorphs first contents: aString]