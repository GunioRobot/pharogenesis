getResponseNoLF
	"Get the response to the last command."

	| buf response bytesRead c lf |
	(self waitForDataUntil: (self class deadlineSecs: 20)) 
		ifFalse: [self error: 'getResponse timeout'].
	lf := Character lf.
	buf := String new: 1000.
	response := WriteStream on: ''.
	[self dataAvailable] whileTrue: 
			[bytesRead := self 
						primSocket: socketHandle
						receiveDataInto: buf
						startingAt: 1
						count: buf size.
			1 to: bytesRead
				do: [:i | (c := buf at: i) ~= lf ifTrue: [response nextPut: c]]].
	^response contents