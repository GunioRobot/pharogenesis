primitiveSocket: socket sendUDPData: array toHost: hostAddress  port: portNumber start: startIndex count: count 
	| s byteSize arrayBase bufStart bytesSent address |
	self var: #s declareC: 'SocketPtr s'.
	self primitive: 'primitiveSocketSendUDPDataBufCount'
		parameters: #(Oop Oop ByteArray SmallInteger SmallInteger SmallInteger ).
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
			address _ self netAddressToInt: (self cCoerce: hostAddress to: 'unsigned char *').
			bytesSent _ self
						sqSocket: s
						toHost: address
						port: portNumber
						SendDataBuf: bufStart
						Count: count * byteSize].
	^ (bytesSent // byteSize) asSmallIntegerObj