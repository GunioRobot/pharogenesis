getRestOfBuffer: beginning
	"We don't know the length.  Keep going until connection is closed.  Part of it has already been received.  Response is of type text, not binary."

	| buf response bytesRead |
	response _ RWBinaryOrTextStream on: (String new: 2000).
	response nextPutAll: beginning.
	buf _ String new: 2000.

	[self isConnected | self dataAvailable] 
	whileTrue: [
		(self waitForDataUntil: (Socket deadlineSecs: 5)) ifFalse: [
	 		Transcript show: 'data was slow'; cr].
		bytesRead _ self primSocket: socketHandle receiveDataInto: buf 
				startingAt: 1 count: buf size. 
		bytesRead > 0 ifTrue: [  
			response nextPutAll: (buf copyFrom: 1 to: bytesRead)] ].
	self logToTranscript ifTrue: [
		Transcript cr; show: 'data byte count: ', response position printString].
	response reset.	"position: 0."
	^ response
