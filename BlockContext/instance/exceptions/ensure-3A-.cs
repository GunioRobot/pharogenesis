ensure: aBlock
	"Evaluate a termination block after evaluating the receiver, regardless of whether the receiver's evaluation completes."

	| returnValue |
	returnValue := self valueUninterruptably.
	"aBlock wasn't nil when execution of this method began; it is nil'd out by the unwind machinery, and that's how we know it's already been evaluated ... otherwise, obviously, it needs to be evaluated"
	aBlock == nil
		ifFalse: [aBlock value].
	^returnValue