socketValueOf: socketOop 
	"Return a pointer to the first byte of of the socket record within the  
	given Smalltalk object, or nil if socketOop is not a socket record."
	| socketIndex |
	self returnTypeC: 'SQSocket *'.
	interpreterProxy success: ((interpreterProxy isBytes: socketOop)
			and: [(interpreterProxy byteSizeOf: socketOop)
					= self socketRecordSize]).
	interpreterProxy failed
		ifTrue: [^ nil]
		ifFalse: [socketIndex _ self cCoerce: (interpreterProxy firstIndexableField: socketOop)
						to: 'int'.
			^ self cCode: '(SQSocket *) socketIndex']