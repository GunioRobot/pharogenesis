primitiveSocket: socket receiveDataBuf: array start: startIndex count: count 
	| s byteSize arrayBase bufStart bytesReceived |
	self var: #s declareC: 'SocketPtr s'.
	self primitive: 'primitiveSocketReceiveDataBufCount'
		parameters: #(Oop Oop SmallInteger SmallInteger ).
	s _ self socketValueOf: socket.

	"buffer can be any indexable words or bytes object"
	interpreterProxy success: (interpreterProxy isWordsOrBytes: array).
	(interpreterProxy isWords: array)
		ifTrue: [byteSize _ 4]
		ifFalse: [byteSize _ 1].
	interpreterProxy success: (startIndex >= 1
			and: [count >= 0 and: [startIndex + count - 1 <= (interpreterProxy slotSizeOf: array)]]).
	interpreterProxy failed
		ifFalse: ["Note: adjust bufStart for zero-origin indexing"
			arrayBase _ self cCoerce: (interpreterProxy firstIndexableField: array)
						to: 'int'.
			bufStart _ arrayBase + (startIndex - 1 * byteSize).
			bytesReceived _ self
						sqSocket: s
						ReceiveDataBuf: bufStart
						Count: count * byteSize].
	^ (bytesReceived // byteSize) asSmallIntegerObj