noteRoot: rootClass possiblyAffected: targetClass
	rootClasses add: rootClass.
	targetClass withAllSuperclassesDo: [:sc | 
		(self possiblyAffectedForRoot: rootClass) add: sc. rootClass = sc ifTrue: [^self]]
