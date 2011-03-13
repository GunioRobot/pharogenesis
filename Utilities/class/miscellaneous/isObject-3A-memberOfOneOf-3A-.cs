isObject: anObject memberOfOneOf: aCollectionOfClassnames
	aCollectionOfClassnames do:
		[:classname | (anObject isMemberOf: (Smalltalk at: classname)) ifTrue: [^ true]].
	^ false