color: sensitiveColor sees: soughtColor 
	"Return true if any of my pixels of sensitiveColor intersect with pixels of soughtColor."

	"Make a mask with black where sensitiveColor is, white elsewhere"

	| myImage sensitivePixelMask map patchBelowMe tfm morphAsFlexed i1 pasteUp |
	pasteUp _ self world ifNil: [ ^false ].
	tfm := self transformFrom: pasteUp.
	morphAsFlexed := tfm isIdentity 
				ifTrue: [self]
				ifFalse: [TransformationMorph new flexing: self clone byTransformation: tfm].
	myImage := morphAsFlexed imageForm offset: 0 @ 0.
	sensitivePixelMask := Form extent: myImage extent depth: 1.
	"ensure at most a 16-bit map"
	map := Bitmap new: (1 bitShift: (myImage depth - 1 min: 15)).
	map at: (i1 := sensitiveColor indexInMap: map) put: 1.
	sensitivePixelMask 
		copyBits: sensitivePixelMask boundingBox
		from: myImage form
		at: 0 @ 0
		colorMap: map.

	"get an image of the world below me"
	patchBelowMe := pasteUp 
				patchAt: morphAsFlexed fullBounds
				without: self
				andNothingAbove: false.
	"
sensitivePixelMask displayAt: 0@0.
patchBelowMe displayAt: 100@0.
"
	"intersect world pixels of the color we're looking for with the sensitive pixels"
	map at: i1 put: 0.	"clear map and reuse it"
	map at: (soughtColor indexInMap: map) put: 1.
	sensitivePixelMask 
		copyBits: patchBelowMe boundingBox
		from: patchBelowMe
		at: 0 @ 0
		clippingBox: patchBelowMe boundingBox
		rule: Form and
		fillColor: nil
		map: map.
	"
sensitivePixelMask displayAt: 200@0.
"
	^(sensitivePixelMask tallyPixelValues second) > 0