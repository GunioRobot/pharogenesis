pauseEventRecorderIn: aWorld
	"Suspend any recorder prior to a project change, and return it.
	It will be resumed after starting the new project."
	eventListeners ifNil:[^nil].
	Smalltalk at: #EventRecorderMorph ifPresent: [ :class |.
		eventListeners do:
			[:er | (er isKindOf: class) ifTrue: [^ er pauseIn: aWorld]]].
	^ nil