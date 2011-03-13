nextPutAllWordArray: aWordArray

	| ba hackwa hackba blt rowsAtATime sourceOrigin rowsRemaining |

	self flag: #bob.		"do we need to be concerned by bytesPerElement??"
	ba _ nil.
	rowsAtATime _ 2000.		"or 8000 bytes"
	hackwa _ Form new hackBits: aWordArray.
	sourceOrigin _ 0@0.
	[(rowsRemaining _ hackwa height - sourceOrigin y) > 0] whileTrue: [
		rowsAtATime _ rowsAtATime min: rowsRemaining.
		(ba isNil or: [ba size ~= (rowsAtATime * 4)]) ifTrue: [
			ba _ ByteArray new: rowsAtATime * 4.
			hackba _ Form new hackBits: ba.
			blt _ (BitBlt toForm: hackba) sourceForm: hackwa.
		].
		blt 
			combinationRule: Form over;
			sourceOrigin: sourceOrigin;
			destX: 0 destY: 0 width: 4 height: rowsAtATime;
			copyBits.
		self bufferStream nextPutAll: ba.
		self flushBuffer.
		sourceOrigin _ sourceOrigin x @ (sourceOrigin y + rowsAtATime).
	].
