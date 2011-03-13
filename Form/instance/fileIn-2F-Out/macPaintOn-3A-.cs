macPaintOn: stream
	"Write the form to the stream in MacPaint format." 

	| scanLineForm scanLineBits scanLineBitBlt topMargin leftMargin |
	(width > 576) | (height > 720) ifTrue:
		[(width <=720 and: [height <= 576]) ifTrue:
			[^ (self rotateBy: #left centerAt: 0@0) macPaintOn: stream].
		self error: 'Form too big for MacPaint' ].
	stream nextPutAll: (ByteArray new: 512).	"The header"

	"BitBlt wants even # bytes, but Macpaint format wants
	73 bytes per line, so have to skip -1 after each write."
	scanLineBits _ ByteArray new: 74.
	scanLineBits at: 1 put: 71.	"Magic number for un-compressed images"
	scanLineForm _ Form new.
	scanLineForm setExtent: 584@1	"8 bits on left for magic number"
		offset: 0@0
		bits: scanLineBits.
	leftMargin _ ((576 - width) / 2) asInteger + 8.
	scanLineBitBlt _ BitBlt destForm: scanLineForm
		sourceForm: self
		fillColor: nil
		combinationRule: Form over
		destOrigin: leftMargin@0
		sourceOrigin: 0@0
		extent: width@1
		clipRect: (leftMargin@0 extent: (leftMargin+width)@1).

	topMargin _ ((720 - height) / 3) asInteger.
	scanLineBitBlt sourceForm: nil; fillColor: (Color white); copyBits.
	topMargin timesRepeat:
		[ stream nextPutAll: scanLineBits; skip: -1 ].

	scanLineBitBlt sourceForm: self; fillColor: nil; copyBits.
	0 to: height - 1 do: [ :n |
		scanLineBitBlt sourceY: n; copyBits.
		stream nextPutAll: scanLineBits; skip: -1 ].

	topMargin _ (720 - height - topMargin).
	scanLineBitBlt sourceForm: nil; fillColor: (Color white); copyBits.
	topMargin timesRepeat:
		[ stream nextPutAll: scanLineBits; skip: -1 ].

	(stream isKindOf: FileStream) ifTrue:
		[stream setType: 'PNTG' creator: 'MPNT']

	"To turn some rectangle on the screen into a MacPaint file do:
	| f |
	f _ FileStream fileNamed: 'STScreen0'.
	Form fromUser macPaintOn: f.
	f close.
	"