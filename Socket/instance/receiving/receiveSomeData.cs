receiveSomeData
	"Receive currently available data (if any). Do not wait."
 
	| buffer bytesRead |
	buffer _ String new: 2000.
	bytesRead _ self receiveSomeDataInto: buffer.
	^buffer copyFrom: 1 to: bytesRead