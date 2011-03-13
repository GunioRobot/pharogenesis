allProjects

	^AllProjects ifNil: [
		Smalltalk garbageCollect.
		AllProjects _ self allSubInstances select: [:p | p name notNil].
	].