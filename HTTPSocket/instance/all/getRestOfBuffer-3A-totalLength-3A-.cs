getRestOfBuffer: beginning totalLength: length
	"Reel in a string of a fixed length.  Part of it has already been received.  Close the connection after all chars are received.  We do not strip out linefeed chars.  tk 6/16/97 22:32" 

	| buf response bytesRead |
	length isInteger ifFalse: [self error: 'header parsed wrongly'].
	buf _ String new: length.
	response _ RWBinaryOrTextStream on: buf.
	response nextPutAll: beginning.
	[(response position < length) & (self dataAvailable | self isConnected)] whileTrue: [
		(self waitForDataUntil: (Socket deadlineSecs: 5)) ifFalse: [
			Transcript show: 'data was late'; cr].
		bytesRead _ self primSocket: socketHandle receiveDataInto: buf 
			startingAt: response position + 1 count: buf size - response position.
		"bytesRead = 0 ifTrue: [self error: 'why no data?']."
		"response position+1 to: response position+bytesRead do: [:ii | 
			response nextPut: (buf at: ii)].	totally redundant, but needed to advance position!"
		response instVarAt: 2 "position" put: 
			(response position + bytesRead)].	"horrible, but fast"
	Transcript cr; show: 'data byte count: ', response position printString.
	Transcript cr; show: ((self isConnected) ifTrue: ['Over length by: ', bytesRead printString] 
		ifFalse: ['Socket closed']). 
	"response text.	is already a text stream"
	response reset.	"position: 0."
	^ response
