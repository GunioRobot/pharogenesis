value: arg1 ifError: aBlock
	"Evaluate the block represented by the receiver. If an error occurs aBlock is evaluated
	 with the error message and the receiver as parameters. The receiver should not contain
	 an explicit return statement as this would leave an obsolete error handler hanging around."

	| lastHandler val activeProcess |
	activeProcess _ Processor activeProcess.
	lastHandler _ activeProcess errorHandler.
	activeProcess errorHandler: [:aString :aReceiver |
		activeProcess errorHandler: lastHandler.
		^ aBlock value: aString value: aReceiver].
	val _ self value: arg1.
	activeProcess errorHandler: lastHandler.
	^ val