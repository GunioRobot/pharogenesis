evaluate
	"Evaluate the receiver, and if value has changed, signal value-changed"

	| result |
	result := arguments isEmptyOrNil
		ifTrue: [self receiver perform: selector]
		ifFalse: [self receiver perform: selector withArguments: arguments asArray].
	timeStamp := Time dateAndTimeNow.
	result ~= lastValue ifTrue:
		[lastValue := result.
		self changed: #value]
	