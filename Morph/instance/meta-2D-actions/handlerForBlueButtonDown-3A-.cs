handlerForBlueButtonDown: anEvent
	"Return the (prospective) handler for a mouse down event. The handler is temporarily installed and can be used for morphs further down the hierarchy to negotiate whether the inner or the outer morph should finally handle the event.
	Note: Halos handle blue button events themselves so we will only be asked if there is currently no halo on top of us."
	self wantsHaloFromClick ifFalse:[^nil].
	anEvent handler ifNil:[^self].
	anEvent handler isPlayfieldLike ifTrue:[^self]. "by default exclude playfields"
	(anEvent shiftPressed)
		ifFalse:[^nil] "let outer guy have it"
		ifTrue:[^self] "let me have it"
