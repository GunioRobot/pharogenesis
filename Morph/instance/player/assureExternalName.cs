assureExternalName
	self knownName ifNil:
		[self setNameTo: self externalName]