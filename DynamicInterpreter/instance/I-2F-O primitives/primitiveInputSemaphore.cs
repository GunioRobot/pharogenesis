primitiveInputSemaphore
	"Register the input semaphore. If the argument is not a Semaphore, unregister the current input semaphore."

	| arg |
	arg _ self popStack.
	((self fetchClassOf: arg) = (self splObj: ClassSemaphore)) ifTrue: [
		self storePointer: TheInputSemaphore ofObject: specialObjectsOop withValue: arg.
	] ifFalse: [
		self storePointer: TheInputSemaphore ofObject: specialObjectsOop withValue: nilObj.
	].