dumpHeader: hdr
	| cc |
	^ String streamContents:
		[:strm |
		strm nextPutAll: '<cc=', (cc_ (hdr >> 12) bitAnd: 16r1F) hex.
			cc > 0 ifTrue:
				[strm nextPutAll: ':' , (self nameOfClass: (self compactClassAt: cc))].
			strm nextPutAll: '>'.
		strm nextPutAll: '<ft=', ((hdr bitShift: -8) bitAnd: 16rF) hex , '>'.
		strm nextPutAll: '<sz=', (hdr bitAnd: 16rFC) hex , '>'.
		strm nextPutAll: '<hdr=', (#(big class gcMark short) at: (hdr bitAnd: 3) +1) , '>'.
		]