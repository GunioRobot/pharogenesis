readHeader
	| is89 byte hasColorMap |
	(self hasMagicNumber: 'GIF87a' asByteArray)
		ifTrue: [is89 _ false]
		ifFalse: [(self hasMagicNumber: 'GIF89a' asByteArray)
			ifTrue: [is89 _ true]
			ifFalse: [^ self error: 'This does not appear to be a GIF file']].
	self readWord.	"skip Screen Width"
	self readWord.	"skip Screen Height"
	byte _ self next.
	hasColorMap _ (byte bitAnd: 16r80) ~= 0.
	bitsPerPixel _ (byte bitAnd: 7) + 1.
	byte _ self next.	"skip background color."
	self next ~= 0
		ifTrue: [is89
			ifFalse: [^self error: 'corrupt GIF file (screen descriptor)']].
	hasColorMap
		ifTrue:
			[colorPalette _ self readColorTable: (1 bitShift: bitsPerPixel)]
		ifFalse:
			["Transcript cr; show: 'GIF file does not have a color map.'."
			colorPalette _ nil "Palette monochromeDefault"].