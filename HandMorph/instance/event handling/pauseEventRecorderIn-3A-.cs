pauseEventRecorderIn: aWorld
	"Suspend any recorder prior to a project change, and return it.
	It will be resumed after starting the new project."

	eventSubscribers do:
		[:er | (er isKindOf: EventRecorderMorph) ifTrue: [^ er pauseIn: aWorld]].
	^ nil