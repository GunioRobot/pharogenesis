compressGZip
	| ba hackwa hackba blt rowsAtATime sourceOrigin rowsRemaining bufferStream gZipStream |

"just hacking around to see if further compression would help Nebraska"

	bufferStream _ RWBinaryOrTextStream on: (ByteArray new: 5000).
	gZipStream _ GZipWriteStream on: bufferStream.

	ba _ nil.
	rowsAtATime _ 20000.		"or 80000 bytes"
	hackwa _ Form new hackBits: self.
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
		"bufferStream nextPutAll: ba."
		sourceOrigin _ sourceOrigin x @ (sourceOrigin y + rowsAtATime).
	].
	gZipStream close.
	^bufferStream contents
