nextWordsInto: aBitmap 
	| blt pos mainX mainY frontX frontY little source |
	"Fill the word based buffer from my collection.  Stored on stream as Little Endian.  Optimized for speed."

	(collection class isBytes) ifTrue:
		["1 to: aBitmap size do: [:index | aBitmap at: index put: (self nextNumber: 4)]."
		little _ Smalltalk endianness == #little.
		collection basicSize \\ 4 = 0 
			ifTrue: [source _ collection.  
					pos _ self position.
					self skip: aBitmap size * aBitmap bytesPerElement "1, 2, or 4"]
			ifFalse: [source _ self next: aBitmap size * aBitmap bytesPerElement.
						"forced to copy it into a buffer"
					pos _ 0].
		mainX _ pos \\ 4.   mainY _ pos // 4.	"two Blts required if not word aligned"
		frontX _ 0.  frontY _ mainY + 1.
		blt _ (BitBlt current toForm: (Form new hackBits: aBitmap)) 
					sourceForm: (Form new hackBits: source).
		blt combinationRule: Form over.  "store"
		blt sourceX: mainX; sourceY: mainY; height: aBitmap basicSize; width: 4-mainX.
		blt destX: 0; destY: 0.
		little ifTrue: [blt sourceX: 0; destX: mainX].	"just happens to be this way!"
		blt copyBits.
		mainX = 0 ifTrue: [^ aBitmap].

		"second piece when not word aligned"
		blt sourceX: frontX; sourceY: frontY; height: aBitmap size; width: mainX.
		blt destX: 4-mainX; destY: 0.
		little ifTrue: [blt sourceX: 4-mainX; destX: frontX].	"draw picture to understand this"
		blt copyBits.
		^ aBitmap].
	^ self next: aBitmap size into: aBitmap startingAt: 1.
