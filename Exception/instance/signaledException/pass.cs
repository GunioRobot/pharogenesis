pass
	"Yield control to the enclosing exception action for the receiver."

	self setHandlerFrom: handlerContext sender.
	handlerContext == nil
		ifTrue:
			[self defaultAction.
			self isResumable
				ifTrue: [self resume]
				ifFalse: [IllegalResumeAttempt signal]]
		ifFalse: [self handlerAction]