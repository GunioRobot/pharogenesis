activeDirectoryClass
	FileDirectory subclasses do:
		[:dirClass | dirClass isActive ifTrue: [^ dirClass]].
	^ self halt "No responding subclass"