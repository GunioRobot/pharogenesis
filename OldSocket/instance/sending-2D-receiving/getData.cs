getData
	"Get some data"

	| buf bytesRead |
	(self waitForDataUntil: self class standardDeadline) 
		ifFalse: [self error: 'getData timeout'].
	buf := String new: 4000.
	bytesRead := self 
				primSocket: socketHandle
				receiveDataInto: buf
				startingAt: 1
				count: buf size.
	^buf copyFrom: 1 to: bytesRead