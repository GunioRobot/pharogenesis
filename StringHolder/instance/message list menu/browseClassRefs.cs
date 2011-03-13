browseClassRefs

	| cls |
	(cls _ self selectedClass) ifNotNil: [
		Smalltalk browseAllCallsOn: (Smalltalk associationAt: cls theNonMetaClass name)]
