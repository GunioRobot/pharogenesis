hexDump100: oop
	| byteSize val |
	^ String streamContents:
		[:strm |
		byteSize _ 256.
		(self headerStart: oop) to: byteSize by: 4 do:
			[:a | val _ self longAt: oop+a.
			strm cr; nextPutAll: (oop+a) hex8; space; space; 
				nextPutAll: (a<16 ifTrue: [' ', a hex] ifFalse: [a hex]); 
				space; space; space; nextPutAll: val hex8;
				space; space.
			strm nextPutAll: (self charsOfLong: val).
			strm space; space; nextPutAll: (oop+a) printString]]