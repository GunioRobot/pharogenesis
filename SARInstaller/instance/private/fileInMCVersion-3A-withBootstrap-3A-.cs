fileInMCVersion: member withBootstrap: mcBootstrap
	"This will use the MCBootstrapLoader to load a (non-compressed) Monticello file (.mc or .mcv)"
	| newCS |
	self class withCurrentChangeSetNamed: member localFileName
		do: [ :cs | 
			newCS _ cs.
			mcBootstrap loadStream: member contentStream ascii ].

	newCS isEmpty ifTrue: [ ChangeSorter removeChangeSet: newCS ].

	World doOneCycle.

	self installed: member.