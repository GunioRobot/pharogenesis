memberNamed: aString
	^(zip member: aString)
		ifNil: [ | matching |
			matching _ zip membersMatching: aString.
			matching isEmpty ifFalse: [ matching last ]].