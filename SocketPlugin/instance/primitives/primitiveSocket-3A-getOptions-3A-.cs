primitiveSocket: socket getOptions: optionName

	| s optionNameStart optionNameSize returnedValue errorCode results |
	self var: #s declareC: 'SocketPtr s'.
	self primitive: 'primitiveSocketGetOptions'
		parameters: #(Oop Oop).

	s _ self socketValueOf: socket.
	interpreterProxy success: (interpreterProxy isBytes: optionName).
	optionNameStart _ self cCoerce: (interpreterProxy firstIndexableField: optionName) to: 'int'.
	optionNameSize _ interpreterProxy slotSizeOf: optionName.

	interpreterProxy failed ifTrue: [^nil].
	returnedValue _ 0.

	errorCode _ self sqSocketGetOptions: s 
			optionNameStart: optionNameStart 
			optionNameSize: optionNameSize
			returnedValue: (self cCode: '&returnedValue').

	interpreterProxy pushRemappableOop: returnedValue asSmallIntegerObj.
	interpreterProxy pushRemappableOop: errorCode asSmallIntegerObj.
	interpreterProxy pushRemappableOop: (interpreterProxy instantiateClass: (interpreterProxy classArray) indexableSize: 2).
	results _ interpreterProxy popRemappableOop.
	interpreterProxy storePointer: 0 ofObject: results withValue: interpreterProxy popRemappableOop.
	interpreterProxy storePointer: 1 ofObject: results withValue: interpreterProxy popRemappableOop.
	^ results