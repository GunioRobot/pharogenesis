receiveAvailableData
	"Receive all available data (if any). Do not wait."
 
	| buffer bytesRead |
	buffer _ String new: 2000.
	bytesRead _ self receiveAvailableDataInto: buffer.
	^buffer copyFrom: 1 to: bytesRead