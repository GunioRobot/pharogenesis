receiveDataIfAvailable
	"Only used to check if after dataAvailable on the socket is true that there really are data.
	See also isDataAvailable"
	| buffer bytesRead |

	buffer _ self streamBuffer: 1.

	bytesRead :=self socket receiveSomeDataInto: buffer.
	bytesRead > 0
		ifTrue: [
			inStream := ReadStream on: (self inStream upToEnd , (buffer copyFrom: 1 to: bytesRead))]