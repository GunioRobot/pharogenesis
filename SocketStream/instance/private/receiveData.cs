receiveData
	| buffer bytesRead |

	buffer _ self streamBuffer: self bufferSize.
	bytesRead := self shouldTimeout
		ifTrue: [self socket receiveDataTimeout: self timeout into: buffer]
		ifFalse: [self socket receiveDataInto: buffer].
	bytesRead > 0
		ifTrue: [
			inStream := ReadStream on: (self inStream upToEnd , (buffer copyFrom: 1 to: bytesRead))]