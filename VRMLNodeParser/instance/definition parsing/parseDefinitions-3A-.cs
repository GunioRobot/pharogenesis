parseDefinitions: aVRMLStream
	| nodes |
	aVRMLStream reset.
	nodes := OrderedCollection new.
	[aVRMLStream skipSeparators.
	aVRMLStream atEnd] whileFalse:[
		nodes add: (self parseDefinition: aVRMLStream).
	].
	^nodes