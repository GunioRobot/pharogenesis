longPrint: oop
	| lastPtr val lastLong hdrType prevVal |
	(self isIntegerObject: oop) ifTrue: [^ self shortPrint: oop].
	^ String streamContents:
		[:strm |
		lastPtr _ 256 min: (self lastPointerOf: oop).
		hdrType _ self headerType: oop.
		hdrType = 2 ifTrue: [lastPtr _ 0].
		prevVal _ 0.
		(self headerStart: oop) to: lastPtr by: 4 do:
			[:a | val _ self longAt: oop+a.
			(a > 0 and: [(val = prevVal) & (a ~= lastPtr)])
			ifTrue:
			[prevVal = (self longAt: oop+a-8) ifFalse: [strm cr; nextPutAll: '        ...etc...']]
			ifFalse:
			[strm cr; nextPutAll: (a<16 ifTrue: [' ', a hex] ifFalse: [a hex]); 
				space; space; space; nextPutAll: val hex8; space; space.
			a=-8 ifTrue: [strm nextPutAll: 'size = ' , (val - hdrType) hex].
			a=-4 ifTrue: [strm nextPutAll: '<' , (self nameOfClass: (val - hdrType)) , '>'].
			a=0 ifTrue: [strm cr; tab; nextPutAll: (self dumpHeader: val)].
			a>0 ifTrue: [strm nextPutAll: (self shortPrint: val)].
			a=4 ifTrue: [(self fetchClassOf: oop) = (self splObj: ClassCompiledMethod) ifTrue:
							[strm cr; tab; nextPutAll: (self dumpMethodHeader: val)]]].
			prevVal _ val].
		lastLong _ 256 min: (self sizeBitsOf: oop) - 4.
		hdrType = 2
			ifTrue: ["free" strm cr; nextPutAll: (oop+(self longAt: oop)-2) hex;
				space; space; nextPutAll: (oop+(self longAt: oop)-2) printString]
			ifFalse: [lastPtr+4 to: lastLong by: 4 do:
				[:a | val _ self longAt: oop+a.
				strm cr; nextPutAll: (a<16 ifTrue: [' ', a hex] ifFalse: [a hex]); 
					space; space; space.
				strm nextPutAll: val hex8; space; space;
						nextPutAll: (self charsOfLong: val)]].
	]