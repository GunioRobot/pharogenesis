resume: resumptionValue
	"Return the argument as the value of the message that signaled the receiver."


	| tc |
	self isResumable ifFalse: [IllegalResumeAttempt signal].
	tc := thisContext.
	tc unwindTo: initialContext.
	tc terminateTo: initialContext.
	^resumptionValue