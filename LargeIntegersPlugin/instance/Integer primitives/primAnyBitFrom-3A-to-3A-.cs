primAnyBitFrom: from to: to 
	| integer large |
	self debugCode: [self msg: 'primAnyBitFrom: from to: to'].
	integer _ self
				primitive: 'primAnyBitFromTo'
				parameters: #(#SmallInteger #SmallInteger )
				receiver: #Integer.
	(interpreterProxy isIntegerObject: integer)
		ifTrue: ["convert it to a not normalized LargeInteger"
			large _ self createLargeFromSmallInteger: integer]
		ifFalse: [large _ integer].
	^ (self
		anyBitOfBytes: large
		from: from
		to: to)
		asOop: Boolean