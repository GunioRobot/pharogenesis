open
	"ProcessBrowser open"
	"Create and schedule a ProcessBrowser."
	Smalltalk garbageCollect.
	^ Smalltalk isMorphic
		ifTrue: [ self new openAsMorph ]
		ifFalse: [ self new openAsMVC ]