receiveDataTimeout: timeout
	"Receive data into the given buffer and return the number of bytes received. 
	Note the given buffer may be only partially filled by the received data.
	Waits for data once."

	| buffer bytesRead |
	buffer _ String new: 2000.
	bytesRead _ self receiveDataTimeout: timeout into: buffer.
	^buffer copyFrom: 1 to: bytesRead