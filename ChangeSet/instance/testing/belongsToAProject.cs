belongsToAProject

	Smalltalk at: #Project ifPresent:
		[:projClass | projClass allSubInstancesDo:
			[:proj | proj projectChangeSet == self ifTrue: [^ true]]].
	^ false