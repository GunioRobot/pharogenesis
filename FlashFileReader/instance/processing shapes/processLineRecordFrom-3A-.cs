processLineRecordFrom: data
	| nBits x y |
	nBits _ (data nextBits: 4) + 2. "Offset by 2"
	data nextBitFlag ifTrue:[
		"General line"
		x _ data nextSignedBits: nBits.
		y _ data nextSignedBits: nBits.
		self recordLineSegmentBy: x@y.
	] ifFalse:[
		data nextBitFlag 
			ifTrue:[	"vertical line"
					y _ data nextSignedBits: nBits. 
					self recordLineSegmentVerticalBy: y]
			ifFalse:[	"horizontal line"
					x _ data nextSignedBits: nBits.
					self recordLineSegmentHorizontalBy: x].
	].
	log ifNotNil:[log crtab; nextPutAll:'E: ';print: x; nextPut:$@; print: y.
				self flushLog].