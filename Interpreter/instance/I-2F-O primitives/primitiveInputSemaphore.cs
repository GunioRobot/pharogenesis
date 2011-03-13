primitiveInputSemaphore
	"Register the input semaphore. If the argument is not a Semaphore, unregister the current input semaphore."

	| arg |
	arg _ self stackValue: 0.
	(self isIntegerObject: arg) ifTrue:[
		"If arg is integer, then use it as an index
		 into the external objects array and install it
		 as the new event semaphore"
		self ioSetInputSemaphore: (self integerValueOf: arg).
		successFlag ifTrue:[self pop: 1].
		^nil
	].
	"old code for compatibility"
	arg _ self popStack.
	((self fetchClassOf: arg) = (self splObj: ClassSemaphore)) ifTrue: [
		self storePointer: TheInputSemaphore ofObject: specialObjectsOop withValue: arg.
	] ifFalse: [
		self storePointer: TheInputSemaphore ofObject: specialObjectsOop withValue: nilObj.
	].