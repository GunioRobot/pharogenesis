evaluate
	"Evaluate the receiver, and if value has changed, signal value-changed"

	| result |
	result _ arguments isEmptyOrNil
		ifTrue: [self receiver perform: selector]
		ifFalse: [self receiver perform: selector withArguments: arguments asArray].
	timeStamp _ Time dateAndTimeNow.
	result ~= lastValue ifTrue:
		[lastValue _ result.
		self changed: #value]
	