primitiveSocket: socket sendData: array start: startIndex count: count 
	| s byteSize arrayBase bufStart bytesSent |
	self var: #s declareC: 'SocketPtr s'.
	self primitive: 'primitiveSocketSendDataBufCount'
		parameters: #(Oop Oop SmallInteger SmallInteger ).
	s _ self socketValueOf: socket.

	"buffer can be any indexable words or bytes object except CompiledMethod "
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
			bytesSent _ self
						sqSocket: s
						SendDataBuf: bufStart
						Count: count * byteSize].
	^ (bytesSent // byteSize) asSmallIntegerObj