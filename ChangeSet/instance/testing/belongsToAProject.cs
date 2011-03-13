belongsToAProject

	Project allInstancesDo: [:proj |
		proj projectChangeSet == self ifTrue: [^ true]].
	^ false
