ensure: aBlock
	"Evaluate a termination block after evaluating the receiver, regardless of whether the receiver's evaluation completes."

	| returnValue b |
	<primitive: 198>
	returnValue := self valueNoContextSwitch.
	"aBlock wasn't nil when execution of this method began; it is nil'd out by the unwind machinery, and that's how we know it's already been evaluated ... otherwise, obviously, it needs to be evaluated"
	aBlock == nil ifFalse: [
		"nil out aBlock temp before evaluating aBlock so it is not executed again if aBlock remote returns"
		b := aBlock.
		thisContext tempAt: 1 put: nil.  "Could be aBlock := nil, but arguments cannot be modified"
		b value.
	].
	^ returnValue