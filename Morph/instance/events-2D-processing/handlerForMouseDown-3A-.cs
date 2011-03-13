handlerForMouseDown: anEvent
	"Return the (prospective) handler for a mouse down event. The handler is temporarily installed and can be used for morphs further down the hierarchy to negotiate whether the inner or the outer morph should finally handle the event"
	anEvent blueButtonPressed ifTrue:[^self handlerForBlueButtonDown: anEvent].
	anEvent controlKeyPressed ifTrue:[^self handlerForMetaMenu: anEvent].
	(self handlesMouseDown: anEvent) ifFalse:[^nil]. "not interested"
	anEvent handler ifNil:[^self]. "Nobody else was interested"
	self mouseDownPriority >= anEvent handler mouseDownPriority 
		ifTrue:[^self] "Same priority but I am innermost"
		ifFalse:[^nil]. "Other guy has higher priority than I"