setNamePropertyTo: aName
	extension == nil ifTrue: [self assureExtension].
	extension externalName: aName