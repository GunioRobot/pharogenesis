primitiveSocket: socket receiveUDPDataBuf: array start: startIndex count: count 
	| s byteSize arrayBase bufStart bytesReceived results address port moreFlag |
	self var: #s declareC: 'SocketPtr s'.
	self primitive: 'primitiveSocketReceiveUDPDataBufCount'
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
			"allocate storage for results, remapping newly allocated
			 oops in case GC happens during allocation"
			address		  _ 0.
			port			  _ 0.
			moreFlag	  _ 0.
			bytesReceived _ self
						sqSocket: s
						ReceiveUDPDataBuf: bufStart
						Count: count * byteSize
						address: (self cCode: '&address')
						port: (self cCode: '&port')
						moreFlag: (self cCode: '&moreFlag').
				
			interpreterProxy pushRemappableOop: port asSmallIntegerObj.
			interpreterProxy pushRemappableOop: (self intToNetAddress: address).
			interpreterProxy pushRemappableOop: (bytesReceived // byteSize) asSmallIntegerObj.
			interpreterProxy pushRemappableOop:
				(interpreterProxy instantiateClass: (interpreterProxy classArray) indexableSize: 4).
			results         _ interpreterProxy popRemappableOop.
			interpreterProxy storePointer: 0 ofObject: results withValue: interpreterProxy popRemappableOop.
			interpreterProxy storePointer: 1 ofObject: results withValue: interpreterProxy popRemappableOop.
			interpreterProxy storePointer: 2 ofObject: results withValue: interpreterProxy popRemappableOop.
			moreFlag
				ifTrue: [ interpreterProxy storePointer: 3 ofObject: results withValue: interpreterProxy trueObject ]
				ifFalse: [ interpreterProxy storePointer: 3 ofObject: results withValue: interpreterProxy falseObject ].
			].
	^ results