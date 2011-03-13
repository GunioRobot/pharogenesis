primInputSemaphore: aSemaphore 
	"Primitive. Install the argument, aSemaphore, as the object to be signalled
	whenever an input event occurs. The semaphore will be signaled once
	for every word placed in the input buffer by an I/O device. Fail if the
	argument is neither a Semaphore nor nil. Essential. See Object
	documentation whatIsAPrimitive."

	<primitive: 93>
	^self primitiveFailed