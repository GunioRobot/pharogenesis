stringOf: oop
	| size long nLongs chars |
	^ String streamContents:
		[:strm |
		size _ 100 min: (self stSizeOf: oop).
		nLongs _ size-1//4+1.
		1 to: nLongs do:
			[:i | long _ self longAt: oop + BaseHeaderSize + (i-1*4).
			chars _ self charsOfLong: long.
			strm nextPutAll: (i=nLongs
							ifTrue: [chars copyFrom: 1 to: size-1\\4+1]
							ifFalse: [chars])]]