belongsToAProject
	Project allInstances do: [:each |
		each projectChangeSet == self ifTrue: [^ true]].
	^ false