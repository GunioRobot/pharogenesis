pass
	"Yield control to the enclosing exception action for the receiver."
	| result |
	self setHandlerFrom: handlerContext sender.
	handlerContext == nil
		ifTrue:
			[result _ self defaultAction.
			self isResumable
				ifTrue: [self resume: result]
				ifFalse: [IllegalResumeAttempt signal]]
		ifFalse: [self handlerAction]