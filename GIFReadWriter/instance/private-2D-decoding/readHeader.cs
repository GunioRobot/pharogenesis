readHeader
	| is89 byte hasColorMap array r g b |
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
			[array _ Array new: (1 bitShift: bitsPerPixel).
			1 to: array size do: [:i |
				r _ self next.  g _ self next.  b _ self next.
				array at: i put: (Color r: r g: g b: b range: 255)
				  "depth 32"].
			colorPalette _ array]
		ifFalse:
			["Transcript cr; show: 'GIF file does not have a color map.'."
			colorPalette _ nil "Palette monochromeDefault"].