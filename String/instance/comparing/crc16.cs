crc16

	| crc |
	crc := 0.
	self do: [:c |
		crc := (crc bitXor: (c asciiValue bitShift: 8)) bitAnd: 16rFFFF.
		1 to: 8 do: [:dmy | "due to compiler optimization this is a bit faster than timesRepeat:"
			crc := (crc bitAnd: 16r8000) ~= 0
			 ifTrue: [(crc bitShift: 1) bitXor: 16r1021]
			 ifFalse: [crc bitShift: 1]
		].
	].
	^crc bitAnd: 16rFFFF