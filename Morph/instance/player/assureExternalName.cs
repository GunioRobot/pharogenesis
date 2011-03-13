assureExternalName
	| aName |
	^ (aName _ self knownName) ifNil:
		[self setNameTo: (aName _ self externalName).
		^ aName]