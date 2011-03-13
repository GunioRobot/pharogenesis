outer
	"Evaluate the enclosing exception action for the receiver and return."

	^self isResumable
		ifTrue:
			[self setHandlerFrom: handlerContext sender.
			handlerContext == nil
				ifTrue: [self defaultAction]
				ifFalse: [self handlerAction]]
		ifFalse: [self pass]