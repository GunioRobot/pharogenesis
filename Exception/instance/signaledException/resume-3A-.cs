resume: resumptionValue
	"Return the argument as the value of the message that signaled the receiver."

	| tc |

	handlerContext ifNotNil: [handlerContext tempAt: 3 put: true].
	self isResumable ifFalse: [IllegalResumeAttempt signal].
	tc := thisContext.
	tc unwindTo: initialContext.
	tc terminateTo: initialContext.
	^resumptionValue