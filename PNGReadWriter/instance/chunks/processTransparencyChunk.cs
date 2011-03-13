processTransparencyChunk
	"Transcript show: '  TRANSPARENCY ',chunk printString."
	| red green blue |
	colorType = 0 ifTrue: 
		[ transparentPixelValue := chunk 
			unsignedShortAt: 1
			bigEndian: true.
		^ self ].
	colorType = 2 ifTrue: 
		[ red := chunk at: 2.
		green := chunk at: 2.
		blue := chunk at: 2.
		transparentPixelValue := ((65280 + red << 8) + green << 8) + blue.
		^ self ].
	colorType = 3 ifTrue: 
		[ chunk withIndexDo: 
			[ :alpha :index | 
			palette 
				at: index
				put: ((palette at: index) alpha: alpha / 255) ].
		^ self ]