macPaintOn: stream label: labelDisplayBox
	"Write the form to the stream in MacPaint format.
	 NOTE: this implementation is nearly identical to the equally lengthy macPaintOn: method, from which it was derived (by Frank Ludolph, back in 1988, I believe); if we retain these methods, then surely someone should go to the work of merging them so that there's not so much wasted overlalp.  Modified 2/14/96 sw so that non-HFS versions of filestreams can be used also"

	| scanLineForm scanLineBits scanLineBitBlt topMargin leftMargin labelForm |

	(width > 576) | (height > (720 - (labelDisplayBox height)))
		ifTrue: [ self error: 'Form too big for MacPaint' ].
	stream nextPutAll: (ByteArray new: 512).	"The header"

	scanLineBits _ ByteArray new: 74.
	"BitBlt wants even # bytes, but Macpaint format wants
	73 bytes per line, so have to skip -1 after each write."
	scanLineBits at: 1 put: 71.	"Magic number for un-compressed images"
	scanLineForm _ Form new.
	scanLineForm setExtent: 584@1	"8 bits on left for magic number"
		offset: 0@0
		bits: scanLineBits.
	leftMargin _ ((576 - width) / 2) asInteger + 8.
	labelForm _ Form fromDisplay: labelDisplayBox.
	scanLineBitBlt _ BitBlt destForm: scanLineForm
		sourceForm: labelForm
		fillColor: nil
		combinationRule: Form over
		destOrigin: leftMargin@0
		sourceOrigin: 0@0
		extent: (labelDisplayBox width)@1
		clipRect: (leftMargin@0
				extent: (leftMargin+labelDisplayBox width)@1).

	topMargin _ ((720 - height - (labelDisplayBox height)) / 3) asInteger.
	scanLineBitBlt sourceForm: nil; fillColor: (Color white); copyBits.
	topMargin timesRepeat:
		[ stream nextPutAll: scanLineBits; skip: -1 ].

	scanLineBitBlt sourceForm: labelForm; fillColor: nil; copyBits.
	0 to: (labelDisplayBox height) - 1 do: [ :n |
		scanLineBitBlt sourceY: n; copyBits.
		stream nextPutAll: scanLineBits; skip: -1 ].

	scanLineBitBlt _ BitBlt destForm: scanLineForm
		sourceForm: self
		halftoneForm: nil
		combinationRule: Form over
		destOrigin: leftMargin@0
		sourceOrigin: 0@0
		extent: width@1
		clipRect: (leftMargin@0 extent: (leftMargin+width)@1).
	0 to: height - 1 do: [ :n |
		scanLineBitBlt sourceY: n; copyBits.
		stream nextPutAll: scanLineBits; skip: -1 ].

	topMargin _ (720 - height - (labelDisplayBox height) - topMargin).
	scanLineBitBlt sourceForm: nil; fillColor: (Color white); copyBits.
	topMargin timesRepeat:
		[ stream nextPutAll: scanLineBits; skip: -1 ].

	(stream isKindOf: FileStream) ifTrue:
		[stream setType: 'PNTG' creator: 'MPNT']