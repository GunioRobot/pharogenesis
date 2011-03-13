shouldProcess: rc forSinsIn: sinners 
	rc withAllSuperclassesDo: [:rootSuperClass |
		(sinners includes: rootSuperClass) ifTrue: [^true].
		"theres a rootClass closer to the sin, we don't need to do it again."
		(rc ~= rootSuperClass and: [(rootClasses includes: rootSuperClass)]) ifTrue: [^false]].
	^false.