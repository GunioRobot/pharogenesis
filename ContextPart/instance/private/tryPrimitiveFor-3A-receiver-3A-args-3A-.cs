tryPrimitiveFor: method receiver: receiver args: arguments 
	"Simulate a primitive method, method for the receiver and arguments given
	as arguments to this message.  Answer resuming the context if successful, else
	answer the symbol, #simulatorFail."
	| flag primIndex |
	(primIndex _ method primitive) = 0 ifTrue: [^#simulatorFail].
	^ self doPrimitive: primIndex receiver: receiver args: arguments