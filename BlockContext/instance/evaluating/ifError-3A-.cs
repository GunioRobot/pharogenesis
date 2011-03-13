ifError: errorHandlerBlock
	"Evaluate the block represented by the receiver. If an error occurs the given is evaluated with the error message and the receiver as parameters. The error handler block may return a value to be used if the receiver block gets an error. The receiver should not contain an explicit return statement as this would leave an obsolete error handler hanging around."
	"Examples:
		[1 whatsUpDoc] ifError: [:err :rcvr | ^ 'huh?'].
		[1 / 0] ifError: [:err :rcvr |
			'division by 0' = err
				ifTrue: [^ Float inf]
				ifFalse: [self error: err]]
"

	| lastHandler val activeProcess |
	activeProcess _ Processor activeProcess.
	lastHandler _ activeProcess errorHandler.
	activeProcess errorHandler: [:aString :aReceiver |
		activeProcess errorHandler: lastHandler.
		^ errorHandlerBlock value: aString value: aReceiver].
	val _ self value.
	activeProcess errorHandler: lastHandler.
	^ val
